using System;

namespace MiniPL
{
    public sealed class LexerException : Exception
    {
        public LexerException(string Message)
            : base(Message)
        {
        }
    }
}
