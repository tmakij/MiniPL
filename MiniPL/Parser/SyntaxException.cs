using System;
using MiniPL.Lexer;

namespace MiniPL.Parser
{
    public sealed class SyntaxException : Exception
    {
        public SyntaxException(string Message)
            : base(Message)
        {
        }

        public SyntaxException(Symbol Expected, Symbol Found)
            : this("Expected " + Expected + " but " + Found + " was found")
        {
        }
    }
}
