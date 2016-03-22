﻿namespace MiniPL.AST
{
    public sealed class PrintStatement : IStatement
    {
        private readonly IExpression toPrint;

        public PrintStatement(IExpression ToPrint)
        {
            toPrint = ToPrint;
        }

        public void CheckIdentifiers(UsedIdentifiers Used)
        {
            toPrint.CheckIdentifiers(Used);
        }

        public void CheckType(IdentifierTypes Types)
        {
            toPrint.NodeType(Types);
        }
    }
}
