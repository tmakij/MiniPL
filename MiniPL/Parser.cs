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

        private void Program()
        {
            Statements();
        }

        private void Statements()
        {
            Statement();
            Require(Symbol.SemiColon);

            while (position != tokens.Count && Statement())
            {
                Require(Symbol.SemiColon);
            }
        }

        private bool Statement()
        {
            if (Accept(Symbol.Variable))
            {
                if (!VariableIdentifier())
                {
                    throw new SyntaxException("Expected identifier, but " + symbol + " was found");
                }
                Require(Symbol.Colon);
                if (!Type())
                {
                    throw new SyntaxException("Expected type, but " + symbol + " was found");
                }
                if (Accept(Symbol.Assigment))
                {
                    if (!Expression())
                    {
                        throw new SyntaxException("Expected expression, but " + symbol + " was found");
                    }
                }
                return true;
            }
            if (VariableIdentifier())
            {
                Require(Symbol.Assigment);
                if (!Expression())
                {
                    throw new SyntaxException("Expected expression, but " + symbol + " was found");
                }
                return true;
            }
            if (Accept(Symbol.PrintProcedure))
            {
                if (!Expression())
                {
                    throw new SyntaxException("Expected Expression, but found " + symbol);
                }
                return true;
            }
            return false;
        }

        private bool Expression()
        {
            if (UnaryOperator())
            {
                if (!Operator())
                {
                    throw new SyntaxException("Expected operator, but " + symbol + " was found");
                }
                return true;
            }
            if (Operand())
            {
                if (Operator())
                {
                    if (!Operand())
                    {
                        throw new SyntaxException("Expected operand, but " + symbol + " was found");
                    }
                }
                return true;
            }
            return false;
        }

        private bool Operator()
        {
            return Accept(Symbol.Addition) || Accept(Symbol.Multiplication);
        }

        private bool UnaryOperator()
        {
            return Accept(Symbol.Addition);
        }

        private bool Operand()
        {
            if (VariableIdentifier())
            {
                return true;
            }
            if (Accept(Symbol.IntegerLiteral))
            {
                return true;
            }
            if (Accept(Symbol.ClosureOpen))
            {
                if (Expression())
                {
                    Require(Symbol.ClosureClose);
                    return true;
                }
            }
            return false;
        }

        private bool VariableIdentifier()
        {
            return Accept(Symbol.Identifier);
        }

        private bool Type()
        {
            return Accept(Symbol.IntegerType);
        }

        private void NextToken()
        {
            position++;
            if (position != tokens.Count)
            {
                curr = tokens[position];
                symbol = curr.Symbol;
            }
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
                throw new SyntaxException("Expected "+ Expected + ", but " + symbol + " was found");
            }
            return true;
        }
    }
}
