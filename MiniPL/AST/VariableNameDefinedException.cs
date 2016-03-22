using System;

namespace MiniPL.AST
{
    public sealed class VariableNameDefinedException : Exception
    {
        public VariableIdentifier Identifier { get; }

        public VariableNameDefinedException(VariableIdentifier Identifier)
        {
            this.Identifier = Identifier;
        }
    }
}
