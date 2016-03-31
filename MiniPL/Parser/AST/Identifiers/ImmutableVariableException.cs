using System;

namespace MiniPL.Parser.AST
{
    public sealed class ImmutableVariableException : Exception
    {
        public VariableIdentifier Identifier { get; }

        public ImmutableVariableException(VariableIdentifier Identifier)
        {
            this.Identifier = Identifier;
        }
    }
}
