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

        public void CheckIdentifiers(UsedIdentifiers Used)
        {
            first.CheckIdentifiers(Used);
            second.CheckIdentifiers(Used);
        }

        public MiniPLType NodeType(IdentifierTypes Types)
        {
            MiniPLType firstType = first.NodeType(Types);
            MiniPLType secondType = second.NodeType(Types);
            if (!firstType.Equals(secondType))
            {
                throw new TypeMismatchException(firstType, secondType);
            }
            if (!firstType.HasOperatorDefined(expressionOperator))
            {
                throw new UndefinedOperatorException(firstType, expressionOperator);
            }
            return firstType;
        }

        public ReturnValue Execute(Variables Global)
        {
            ReturnValue firstValue = first.Execute(Global);
            ReturnValue secondValue = second.Execute(Global);

            MiniPLType type = firstValue.Type;

            object retVal = type.BinaryOperation(firstValue.Value, secondValue.Value, expressionOperator);
            return new ReturnValue(type, retVal);
        }
    }
}
