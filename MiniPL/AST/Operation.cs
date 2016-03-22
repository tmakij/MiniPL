namespace MiniPL.AST
{
    public sealed class Operation : IOperand
    {
        public OperatorType Operator;
        public IOperand First, Second;
    }
}
