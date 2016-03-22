using System.Collections.Generic;

namespace MiniPL.AST
{
    public sealed class MiniPLType
    {
        private readonly HashSet<OperatorType> definedOperators = new HashSet<OperatorType>();
        private readonly string name;

        public MiniPLType(string Name, bool IsBoolean)
        {
            name = Name;
            if (IsBoolean)
            {
                definedOperators.Add(OperatorType.Addition);
            }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
