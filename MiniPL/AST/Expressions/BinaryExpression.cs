﻿namespace MiniPL.AST
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
            return firstType;
        }
    }
}
