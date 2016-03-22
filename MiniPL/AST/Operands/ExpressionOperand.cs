﻿namespace MiniPL.AST
{
    public sealed class ExpressionOperand : IOperand
    {
        private readonly IExpression expression;

        public ExpressionOperand(IExpression Expression)
        {
            expression = Expression;
        }

        public void CheckIdentifiers(UsedIdentifiers Used)
        {
            expression.CheckIdentifiers(Used);
        }

        public MiniPLType NodeType(IdentifierTypes Types)
        {
            return expression.NodeType(Types);
        }
    }
}