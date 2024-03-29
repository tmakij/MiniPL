﻿using MiniPL.Parser.AST;
using MiniPL.Lexer;
using System;

namespace MiniPL.Parser
{
    public sealed class Parser
    {
        private readonly TokenStream tokens;
        private Symbol symbol { get { return tokens.Symbol; } }

        private const string expExpression = "expression (operand-operator-operand or (unary operator)-operand)";
        private const string expOperand = "operand (variable, literal or expression between closures)";
        private const string expType = "int, string or bool";
        private const string expIdentifier = "identifier";

        public Parser(TokenStream Tokens)
        {
            tokens = Tokens;
        }

        public AbstractSyntaxTree Parse()
        {
            return Program();
        }

        private AbstractSyntaxTree Program()
        {
            ScopedProgram statements = Statements(Symbol.EndOfInput);
            return new AbstractSyntaxTree(statements);
        }

        private ScopedProgram Statements(Symbol EndOfScopeSymbol)
        {
            IStatement requiredStatement = Statement();
            if (requiredStatement == null)
            {
                throw new SyntaxException("At least one statement is required");
            }
            Require(Symbol.SemiColon);
            ScopedProgram program = new ScopedProgram();
            program.Add(requiredStatement);

            while (!Matches(EndOfScopeSymbol))
            {
                IStatement stm = Statement();
                if (stm == null)
                {
                    throw new SyntaxException("beginning of a statement", symbol);
                }
                Require(Symbol.SemiColon);
                program.Add(stm);
            }
            return program;
        }

        private IStatement Statement()
        {
            if (Accept(Symbol.Variable))
            {
                VariableIdentifier identifierToAssigment = Identifier();
                if (identifierToAssigment == null)
                {
                    throw new SyntaxException(expIdentifier, symbol);
                }
                Require(Symbol.Colon);
                MiniPLType type = Type();
                if (type == null)
                {
                    throw new SyntaxException(expType, symbol);
                }
                IExpression expr = null;
                if (Accept(Symbol.Assigment))
                {
                    expr = Expression();
                    if (expr == null)
                    {
                        throw new SyntaxException(expExpression, symbol);
                    }
                }
                return new DeclarationStatement(identifierToAssigment, type, expr);
            }

            VariableIdentifier varIdent = Identifier();
            if (varIdent != null)
            {
                Require(Symbol.Assigment);
                IExpression expr = Expression();
                if (expr == null)
                {
                    throw new SyntaxException(expExpression, symbol);
                }
                return new AssigmentStatement(varIdent, expr);
            }
            if (Accept(Symbol.For))
            {
                VariableIdentifier iterator = Identifier();
                if (iterator == null)
                {
                    throw new SyntaxException(expIdentifier, symbol);
                }
                Require(Symbol.In);
                IExpression lowBound = Expression();
                if (lowBound == null)
                {
                    throw new SyntaxException(expExpression, symbol);
                }
                Require(Symbol.Range);
                IExpression highBound = Expression();
                if (highBound == null)
                {
                    throw new SyntaxException(expExpression, symbol);
                }
                Require(Symbol.Do);
                ScopedProgram toExecute = Statements(Symbol.End);
                Require(Symbol.End);
                Require(Symbol.For);
                return new ForStatement(iterator, lowBound, highBound, toExecute);
            }
            if (Accept(Symbol.ReadProcedure))
            {
                VariableIdentifier toReadInto = Identifier();
                if (toReadInto == null)
                {
                    throw new SyntaxException(expIdentifier, symbol);
                }
                return new ReadStatement(toReadInto);
            }
            if (Accept(Symbol.PrintProcedure))
            {
                IExpression toPrint = Expression();
                if (toPrint == null)
                {
                    throw new SyntaxException(expExpression, symbol);
                }
                return new PrintStatement(toPrint);
            }
            if (Accept(Symbol.Assert))
            {
                IExpression toAssert = Expression();
                if (toAssert == null)
                {
                    throw new SyntaxException(expExpression, symbol);
                }
                return new AssertStatement(toAssert);
            }
            return null;
        }

        private IExpression Expression()
        {
            if (Accept(Symbol.LogicalNot))
            {
                IOperand opr = Operand();
                if (opr == null)
                {
                    throw new SyntaxException(expOperand, symbol);
                }
                return new UnaryExpression(OperatorType.Negation, opr);
            }
            IOperand firstOperand = Operand();
            if (firstOperand != null)
            {
                OperatorType opr = ReadOperator();
                if (opr == OperatorType.None)
                {
                    return new UnaryExpression(OperatorType.None, firstOperand);
                }
                IOperand secondOperand = Operand();
                if (secondOperand == null)
                {
                    throw new SyntaxException(expOperand, symbol);
                }
                return new BinaryExpression(firstOperand, opr, secondOperand);
            }
            return null;
        }

        private OperatorType ReadOperator()
        {
            if (Accept(Symbol.Addition))
            {
                return OperatorType.Addition;
            }
            if (Accept(Symbol.Multiplication))
            {
                return OperatorType.Multiplication;
            }
            if (Accept(Symbol.Substraction))
            {
                return OperatorType.Substraction;
            }
            if (Accept(Symbol.Division))
            {
                return OperatorType.Division;
            }
            if (Accept(Symbol.Equality))
            {
                return OperatorType.Equals;
            }
            if (Accept(Symbol.LessThan))
            {
                return OperatorType.LessThan;
            }
            if (Accept(Symbol.LogicalAnd))
            {
                return OperatorType.And;
            }
            return OperatorType.None;
        }

        private IOperand Operand()
        {
            if (Matches(Symbol.IntegerLiteral))
            {
                try
                {
                    int val = int.Parse(tokens.Current.Lexeme);
                    tokens.Next();
                    return new IntegerLiteralOperand(val);
                }
                catch(OverflowException)
                {
                    throw new IntegerParseOverflowException(tokens.Current.Lexeme);
                }
            }
            if (Matches(Symbol.StringLiteral))
            {
                string val = tokens.Current.Lexeme;
                tokens.Next();
                return new StringLiteralOperand(val);
            }
            VariableIdentifier varIdent = Identifier();
            if (varIdent != null)
            {
                return new VariableOperand(varIdent);
            }
            if (Accept(Symbol.ClosureOpen))
            {
                IExpression expr = Expression();
                if (expr == null)
                {
                    throw new SyntaxException(expExpression, symbol);
                }
                Require(Symbol.ClosureClose);
                return new ExpressionOperand(expr);
            }
            return null;
        }

        private VariableIdentifier Identifier()
        {
            if (Matches(Symbol.Identifier))
            {
                VariableIdentifier id = new VariableIdentifier(tokens.Current.Lexeme);
                tokens.Next();
                return id;
            }
            return null;
        }

        private MiniPLType Type()
        {
            if (Matches(Symbol.IntegerType))
            {
                tokens.Next();
                return MiniPLType.Integer;
            }
            if (Matches(Symbol.StringType))
            {
                tokens.Next();
                return MiniPLType.String;
            }
            if (Matches(Symbol.BooleanType))
            {
                tokens.Next();
                return MiniPLType.Boolean;
            }
            return null;
        }

        private bool Accept(Symbol Accepted)
        {
            if (Matches(Accepted))
            {
                tokens.Next();
                return true;
            }
            return false;
        }

        private bool Matches(Symbol Expected)
        {
            return symbol == Expected;
        }

        private void Require(Symbol Expected)
        {
            if (!Accept(Expected))
            {
                throw new SyntaxException(Expected.ToString(), symbol);
            }
        }
    }
}
