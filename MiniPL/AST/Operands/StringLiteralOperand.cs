namespace MiniPL.AST
{
    public sealed class StringLiteralOperand : IOperand
    {
        private readonly string literal;

        public StringLiteralOperand(string Literal)
        {
            literal = Literal;
        }
    }
}
