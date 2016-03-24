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

        public void CheckIdentifiers(UsedIdentifiers Used)
        {
            operand.CheckIdentifiers(Used);
        }

        public MiniPLType NodeType(IdentifierTypes Types)
        {
            MiniPLType type = operand.NodeType(Types);
            if (!type.Equals(MiniPLType.Integer))
            {
                throw new TypeMismatchException(MiniPLType.Integer, type);
            }
            return type;
        }

        public ReturnValue Execute(Variables Global)
        {
            return operand.Execute(Global);
        }
    }
}
