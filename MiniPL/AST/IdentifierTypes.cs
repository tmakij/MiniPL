using System.Collections.Generic;

namespace MiniPL.AST
{
    public sealed class IdentifierTypes
    {
        private readonly Dictionary<VariableIdentifier, MiniPLType> types = new Dictionary<VariableIdentifier, MiniPLType>();

        public void SetIdentifierType(VariableIdentifier Identifier, MiniPLType Type)
        {
            types.Add(Identifier, Type);
        }

        public MiniPLType GetIdentifierType(VariableIdentifier Identifier)
        {
            return types[Identifier];
        }
    }
}
