namespace MiniPL.AST
{
    public sealed class VariableOperand : IOperand
    {
        private readonly VariableIdentifier variable;

        public VariableOperand(VariableIdentifier Variable)
        {
            variable = Variable;
        }
    }
}
