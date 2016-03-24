using System.Collections.Generic;
using System.Text;

namespace MiniPL
{
    public sealed class TokenConstruction
    {
        private readonly StringBuilder curr = new StringBuilder();
        private readonly List<Token> tokens = new List<Token>();

        public TokenStream CreateStream()
        {
            return new TokenStream(tokens.AsReadOnly());
        }

        public void Append(char Character)
        {
            curr.Append(Character);
        }

        public void End(Symbol ID)
        {
            string res = TokenText(ID);
            Token t = new Token(res, ID);
            tokens.Add(t);
            string dbg;
            if (ID == Symbol.IntegerLiteral || ID == Symbol.Identifier)
            {
                dbg = ID + ": " + res;
            }
            else
            {
                dbg = ID.ToString();
            }
            System.Console.WriteLine("Read token: " + dbg);
        }

        private string TokenText(Symbol ID)
        {
            switch (ID)
            {
                case Symbol.Variable:
                    curr.Clear();
                    return "var";
                case Symbol.Addition:
                    return "+";
                case Symbol.Multiplication:
                    return "*";
                case Symbol.Assigment:
                    return ":=";
                case Symbol.Colon:
                    return ":";
                case Symbol.ClosureClose:
                    return ")";
                case Symbol.ClosureOpen:
                    return "(";
                case Symbol.SemiColon:
                    return ";";
                case Symbol.EndOfInput:
                    return "EndOfInput";
                case Symbol.IntegerType:
                    curr.Clear();
                    return "int";
                case Symbol.PrintProcedure:
                    curr.Clear();
                    return "PrintProcedure";
                case Symbol.IntegerLiteral:
                case Symbol.Identifier:
                default:
                    string text = curr.ToString();
                    curr.Clear();
                    return text;
            }
        }
    }
}
