using System;

namespace MiniPL.AST
{
    public sealed class IntegerParseOverflowException : Exception
    {
        public string Value { get; }

        public IntegerParseOverflowException(string Value)
        {
            this.Value = Value;
        }
    }
}
