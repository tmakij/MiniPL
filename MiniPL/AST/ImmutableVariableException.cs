using System;

namespace MiniPL.AST
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
