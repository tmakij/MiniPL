using System.Collections.Generic;
using System.Text;

namespace MiniPL
{
    public sealed class TokenConstruction
    {
        private readonly StringBuilder curr = new StringBuilder();
        private readonly List<Token> tokens = new List<Token>();

        public void Append(char Character)
        {
            curr.Append(Character);
        }

        public void End()
        {
            End(TokenID.Identifier);
        }

        public void End(TokenID ID)
        {
            string res = TokenText(ID);
            Token t = new Token(res, ID);
            tokens.Add(t);
            string dbg;
            if (ID == TokenID.IntegerLiteral || ID == TokenID.Identifier)
            {
                dbg = ID +": " + res;
            }
            else
            {
                dbg = ID.ToString();
            }
            System.Console.WriteLine("Read token: " + dbg);
        }

        private string TokenText(TokenID ID)
        {
            switch (ID)
            {
                case TokenID.Variable:
                    curr.Clear();
                    return "var";
                case TokenID.Addition:
                    return "+";
                case TokenID.Multiplication:
                    return "*";
                case TokenID.Assigment:
                    return ":=";
                case TokenID.Colon:
                    return ":";
                case TokenID.ClosureClose:
                    return ")";
                case TokenID.ClosureOpen:
                    return "(";
                case TokenID.SemiColon:
                    return ";";
                case TokenID.IntegerType:
                    curr.Clear();
                    return "int";
                case TokenID.PrintProcedure:
                    curr.Clear();
                    return "PrintProcedure";
                case TokenID.IntegerLiteral:
                case TokenID.Identifier:
                default:
                    string text = curr.ToString();
                    curr.Clear();
                    return text;
            }
        }
    }
}
