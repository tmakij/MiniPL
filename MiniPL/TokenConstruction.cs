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
            string res = curr.ToString();
            curr.Clear();
            Token t = new Token(res);
            tokens.Add(t);
            System.Console.WriteLine("Read token: \"" + t  + "\"");
        }
    }
}
