namespace MiniPL.AST
{
    public sealed class UnaryExpression : IExpression
    {
        private readonly OperatorType expressionOperator;
        private readonly IOperand operand;

        public UnaryExpression(OperatorType Operator, IOperand Operand)
        {
            expressionOperator = Operator;
            operand = Operand;
        }
    }
}
