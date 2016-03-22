namespace MiniPL.AST
{
    public sealed class BinaryExpression : IExpression
    {
        private readonly IOperand first;
        private readonly OperatorType expressionOperator;
        private readonly IOperand second;

        public BinaryExpression(IOperand First, OperatorType Operator, IOperand Second)
        {
            first = First;
            expressionOperator = Operator;
            second = Second;
        }
    }
}
