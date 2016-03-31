namespace MiniPL.Parser.AST
{
    public sealed class IntegerLiteralOperand : IOperand
    {
        private readonly int literal;
        private readonly MiniPLType type;

        public IntegerLiteralOperand(int Literal, MiniPLType Type)
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
