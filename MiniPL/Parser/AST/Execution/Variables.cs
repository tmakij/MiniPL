using System.Collections.Generic;

namespace MiniPL.Parser.AST
{
    public sealed class Variables
    {
        private readonly Dictionary<VariableIdentifier, RuntimeVariable> values = new Dictionary<VariableIdentifier, RuntimeVariable>();

        public void AddIdentifier(VariableIdentifier Identifier, MiniPLType Type)
        {
            values.Add(Identifier, new RuntimeVariable(Type));
        }

        public RuntimeVariable GetValue(VariableIdentifier Identifier)
        {
            return values[Identifier];
        }
    }
}
