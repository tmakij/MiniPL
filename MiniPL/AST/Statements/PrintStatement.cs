namespace MiniPL.AST
{
    public sealed class PrintStatement : IStatement
    {
        private readonly IExpression toPrint;

        public PrintStatement(IExpression ToPrint)
        {
            toPrint = ToPrint;
        }
    }
}
