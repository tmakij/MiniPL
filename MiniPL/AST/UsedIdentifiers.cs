using System.Collections.Generic;

namespace MiniPL.AST
{
    public sealed class UsedIdentifiers
    {
        private readonly HashSet<VariableIdentifier> usedIdentifiers = new HashSet<VariableIdentifier>();

        public bool IsUsed(VariableIdentifier Identifier)
        {
            if (usedIdentifiers.Contains(Identifier))
            {
                return true;
            }
            usedIdentifiers.Add(Identifier);
            return false;
        }
    }
}
