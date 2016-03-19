using System.Collections.Generic;

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

        private SyntaxNode Program()
        {
            SyntaxNode root = Statements();
            Print(1, root);
            return root;
        }

        private void Print(int Level, SyntaxNode Parent)
        {
            System.Console.WriteLine("Level " + Level + ": " +Parent.Symbol);
            foreach (SyntaxNode node in Parent.Children)
            {
                Print(Level + 1,node);
            }
        }

        private SyntaxNode Statements()
        {
            SyntaxNode node = MakeNode(Symbol.EndOfInput);

            SyntaxNode requiredStatement = Statement();
            if (requiredStatement == null)
            {
                throw new SyntaxException("Program requires at least one statement");
            }
            node.Add(requiredStatement);
            Require(Symbol.SemiColon);

            while (symbol != Symbol.EndOfInput)
            {
                node.Add(Statement());
                Require(Symbol.SemiColon);
            }

            return node;
        }

        private SyntaxNode Statement()
        {
            SyntaxNode varAssigment = ReadNode(Symbol.Variable);
            if (varAssigment != null)
            {
                SyntaxNode identifierToAssigment = VariableIdentifier();
                if (identifierToAssigment == null)
                {
                    throw new SyntaxException("Expected identifier, but " + symbol + " was found");
                }
                varAssigment.Add(identifierToAssigment);
                Require(Symbol.Colon);
                SyntaxNode type = Type();
                if (type == null)
                {
                    throw new SyntaxException("Expected type, but " + symbol + " was found");
                }
                varAssigment.Add(type);


                while (true)
                {
                    SyntaxNode multiAssigment = ReadNode(Symbol.Assigment);
                    if (multiAssigment == null)
                    {
                        break;
                    }
                    varAssigment.Add(multiAssigment);
                    SyntaxNode expr = Expression();
                    if (expr == null)
                    {
                        throw new SyntaxException("Expected expression, but " + symbol + " was found");
                    }
                    varAssigment.Add(expr);
                }
                return varAssigment;
            }

            SyntaxNode varIdent = VariableIdentifier();
            if (varIdent != null)
            {
                SyntaxNode assigment = ReadNode(Symbol.Assigment);
                if (assigment == null)
                {
                    throw new SyntaxException(Symbol.Assigment, symbol);
                }
                varIdent.Add(assigment);

                SyntaxNode expr = Expression();
                if (expr == null)
                {
                    throw new SyntaxException("Expected expression, but " + symbol + " was found");
                }
                varIdent.Add(expr);

                return varIdent;
            }

            SyntaxNode printProcedre = ReadNode(Symbol.PrintProcedure);
            if (printProcedre != null)
            {
                SyntaxNode expr = Expression();
                if (expr == null)
                {
                    throw new SyntaxException("Expected Expression, but found " + symbol);
                }
                printProcedre.Add(expr);
                return printProcedre;
            }
            return null;
        }

        private SyntaxNode Expression()
        {
            SyntaxNode unary = UnaryOperator();
            if (unary != null)
            {
                SyntaxNode opr = Operator();
                if (opr == null)
                {
                    throw new SyntaxException("Expected operator, but " + symbol + " was found");
                }
                unary.Add(opr);
                return opr;
            }
            SyntaxNode firstOperand = Operand();
            if (firstOperand != null)
            {
                SyntaxNode opr = Operator();
                if (opr != null)
                {
                    firstOperand.Add(opr);
                    SyntaxNode secondOperand = Operand();
                    if (secondOperand == null)
                    {
                        throw new SyntaxException("Expected operand, but " + symbol + " was found");
                    }
                    firstOperand.Add(secondOperand);
                }
                return firstOperand;
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

        private SyntaxNode UnaryOperator()
        {
            if (Accept(Symbol.Addition))
            {
                MakeNode(Symbol.Addition);
            }
            return null;
        }

        private SyntaxNode Operand()
        {
            SyntaxNode varNode = VariableIdentifier();
            if (varNode != null)
            {
                return varNode;
            }
            SyntaxNode literal = ReadNode(Symbol.IntegerLiteral);
            if (literal != null)
            {
                return literal;
            }
            if (Accept(Symbol.ClosureOpen))
            {
                SyntaxNode expr = Expression();
                if (expr == null)
                {
                    throw new SyntaxException("Expected expression, found " + symbol);
                }
                Require(Symbol.ClosureClose);
                return expr;

            }
            return null;
        }

        private SyntaxNode VariableIdentifier()
        {
            if (Accept(Symbol.Identifier))
            {
                return MakeNode(Symbol.Identifier);
            }
            return null;
        }

        private SyntaxNode Type()
        {
            return ReadNode(Symbol.IntegerType);
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
                //System.Console.WriteLine( Accepted + " === " + symbol);
                NextToken();
                return true;
            }
            return false;
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
