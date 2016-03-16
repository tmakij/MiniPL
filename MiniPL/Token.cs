using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPL
{
    public sealed class Token
    {
        private readonly string text;

        public Token(string Text)
        {
            text = Text;
        }

        public override string ToString()
        {
            return text;
        }
    }
}
