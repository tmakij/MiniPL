namespace MiniPL.AST
{
    public sealed class IntegerLiteralOperand : IOperand
    {
        private readonly int literal;

        public IntegerLiteralOperand(int Literal)
        {
            literal = Literal;
        }
    }
}
