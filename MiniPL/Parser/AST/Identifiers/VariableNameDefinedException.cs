using System;

namespace MiniPL.Parser.AST
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
