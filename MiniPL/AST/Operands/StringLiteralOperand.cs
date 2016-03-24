namespace MiniPL.AST
{
    public sealed class StringLiteralOperand : IOperand
    {
        private readonly string literal;
        private readonly MiniPLType type;

        public StringLiteralOperand(string Literal, MiniPLType Type)
        {
            literal = Literal;
            type = Type;
        }

        public void CheckIdentifiers(UsedIdentifiers Used)
        {
        }

        public MiniPLType NodeType(IdentifierTypes Types)
        {
            return type;
        }

        public ReturnValue Execute(Variables Global)
        {
            return new ReturnValue(type, literal);
        }
    }
}
