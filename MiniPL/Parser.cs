using System.Collections.Generic;
using MiniPL.AST;

namespace MiniPL
{
    public sealed class Parser
    {
        private readonly IList<Token> tokens;
        private Token curr;
        private int position;
        private Symbol symbol;

        public Parser(IList<Token> Tokens)
        {
            tokens = Tokens;
            position = -1;
            NextToken();
        }

        public void Parse()
        {
            Program();
        }

        private Program Program()
        {
            IList<IStatement> root = Statements();
            Program p = new AST.Program()
            {
                Statements = root
            };
            return p;
        }

        private IList<IStatement> Statements()
        {
            IStatement requiredStatement = Statement();
            if (requiredStatement == null)
            {
                throw new SyntaxException("Program must do something!");
            }
            Require(Symbol.SemiColon);
            List<IStatement> statements = new List<IStatement>();
            statements.Add(requiredStatement);

            while (!Matches(Symbol.EndOfInput))
            {
                IStatement stm = Statement();
                if (stm == null)
                {
                    throw new SyntaxException("Expected beginning of a statement, but " + symbol + " was found");
                }
                Require(Symbol.SemiColon);
                statements.Add(stm);
            }

            return statements.AsReadOnly();
        }

        private IStatement Statement()
        {
            if (Accept(Symbol.Variable))
            {
                VariableIdentifier identifierToAssigment = VariableIdentifier();
                if (identifierToAssigment == null)
                {
                    throw new SyntaxException("Expected identifier, but " + symbol + " was found");
                }
                Require(Symbol.Colon);
                IType type = Type();
                if (type == null)
                {
                    throw new SyntaxException("Expected type, but " + symbol + " was found");
                }
                IExpression expr = null;
                if (Accept(Symbol.Assigment))
                {
                    expr = Expression();
                    if (expr == null)
                    {
                        throw new SyntaxException("Expected expression, but " + symbol + " was found");
                    }
                }
                return new DeclarationStatement(identifierToAssigment, type, expr);
            }

            VariableIdentifier varIdent = VariableIdentifier();
            if (varIdent != null)
            {
                Require(Symbol.Assigment);
                IExpression expr = Expression();
                if (expr == null)
                {
                    throw new SyntaxException("Expected expression, but " + symbol + " was found");
                }
                return new AssigmentStatement(varIdent, expr);
            }

            if (Accept(Symbol.PrintProcedure))
            {
                IExpression expr = Expression();
                if (expr == null)
                {
                    throw new SyntaxException("Expected Expression, but found " + symbol);
                }
                return new PrintStatement(expr);
            }
            return null;
        }

        private IExpression Expression()
        {
            /*if (Accept(Symbol.Addition))
            {
                throw new System.NotImplementedException();
                SyntaxNode opr = Operator();
                if (opr == null)
                {
                    throw new SyntaxException("Expected operator, but " + symbol + " was found");
                }
                unary.Add(opr);
                return opr;
            }*/
            IOperand firstOperand = Operand();
            if (firstOperand != null)
            {
                OperatorType? opr = ReadOperator();
                if (!opr.HasValue)
                {
                    return new UnaryExpression(OperatorType.Addition, firstOperand);
                }
                IOperand secondOperand = Operand();
                if (secondOperand == null)
                {
                    throw new SyntaxException("Expected operand, but " + symbol + " was found");
                }
                return new BinaryExpression(firstOperand, opr.Value, secondOperand);
            }
            return null;
        }

        private OperatorType? ReadOperator()
        {
            if (Accept(Symbol.Addition))
            {
                return OperatorType.Addition;
            }
            if (Accept(Symbol.Multiplication))
            {
                return OperatorType.Multiplication;
            }
            return null;
        }

        private SyntaxNode Operator()
        {
            if (Accept(Symbol.Addition))
            {
                return MakeNode(Symbol.Addition);
            }
            if (Accept(Symbol.Multiplication))
            {
                return MakeNode(Symbol.Multiplication);
            }
            return null;
        }

        private OperatorType UnaryOperator()
        {
            if (Accept(Symbol.Addition))
            {
                return OperatorType.Addition;
            }
            return OperatorType.Addition;
        }

        private IOperand Operand()
        {
            VariableIdentifier varIdent = VariableIdentifier();
            if (varIdent != null)
            {
                return new VariableOperand(varIdent);
            }

            if (Matches(Symbol.IntegerLiteral))
            {
                int val = int.Parse(curr.Value);
                NextToken();
                return new IntegerLiteralOperand(val);
            }
            if (Accept(Symbol.ClosureOpen))
            {
                IExpression expr = Expression();
                if (expr == null)
                {
                    throw new SyntaxException("Expected expression, found " + symbol);
                }
                Require(Symbol.ClosureClose);
                return new ExpressionOperand(expr);
            }
            return null;
        }

        private VariableIdentifier VariableIdentifier()
        {
            if (!Matches(Symbol.Identifier))
            {
                return null;
            }
            VariableIdentifier id = new AST.VariableIdentifier()
            {
                Name = curr.Value
            };
            NextToken();
            return id;
        }

        private IType Type()
        {
            if (Matches(Symbol.IntegerType))
            {
                NextToken();
                return new IntegerType();
            }
            return null;
        }

        private void NextToken()
        {
            position++;
            curr = tokens[position];
            symbol = curr.Symbol;
        }

        private bool Accept(Symbol Accepted)
        {
            if (symbol == Accepted)
            {
                NextToken();
                return true;
            }
            return false;
        }

        private bool Matches(Symbol Expected)
        {
            return symbol == Expected;
        }

        private bool Require(Symbol Expected)
        {
            if (!Accept(Expected))
            {
                throw new SyntaxException("Expected " + Expected + ", but " + symbol + " was found");
            }
            return true;
        }

        private SyntaxNode ReadNode(Symbol Symbol)
        {
            if (Accept(Symbol))
            {
                return MakeNode(Symbol);
            }
            return null;
        }

        private SyntaxNode MakeNode(Symbol Symbol)
        {
            SyntaxNode node = new SyntaxNode(Symbol);
            return node;
        }
    }
}
