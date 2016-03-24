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

        public ReturnValue Execute(Variables Global)
        {
            RuntimeVariable var = Global.GetValue(variable);
            return new ReturnValue(var.Type, var.Value);
        }
    }
}
