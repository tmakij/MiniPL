using System;

namespace MiniPL.AST
{
    public sealed class UninitializedVariableException : Exception
    {
        public VariableIdentifier Identifier { get; }

        public UninitializedVariableException(VariableIdentifier Identifier)
        {
            this.Identifier = Identifier;
        }
    }
}
