namespace MiniPL.AST
{
    public sealed class VariableOperand : IOperand
    {
        private readonly VariableIdentifier variable;

        public VariableOperand(VariableIdentifier Variable)
        {
            variable = Variable;
        }

        public void CheckIdentifiers(UsedIdentifiers Used)
        {
            if (!Used.IsUsed(variable))
            {
                throw new UninitializedVariableException(variable);
            }
        }

        public MiniPLType NodeType(IdentifierTypes Types)
        {
            return Types.GetIdentifierType(variable);
        }
    }
}
