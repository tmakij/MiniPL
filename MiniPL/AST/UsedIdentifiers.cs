using System.Collections.Generic;

namespace MiniPL.AST
{
    public sealed class UsedIdentifiers
    {
        private readonly HashSet<VariableIdentifier> usedIdentifiers = new HashSet<VariableIdentifier>();
        private readonly HashSet<VariableIdentifier> immutableIdentifiers = new HashSet<VariableIdentifier>();

        public void DeclareVariable(VariableIdentifier Identifier)
        {
            usedIdentifiers.Add(Identifier);
        }

        public bool IsUsed(VariableIdentifier Identifier)
        {
            return usedIdentifiers.Contains(Identifier);
        }

        public bool IsMutable(VariableIdentifier Identifier)
        {
            return !immutableIdentifiers.Contains(Identifier);
        }

        public void SetMutable(VariableIdentifier Identifier)
        {
            immutableIdentifiers.Remove(Identifier);
        }

        public void SetImmutable(VariableIdentifier Identifier)
        {
            immutableIdentifiers.Add(Identifier);
        }
    }
}
