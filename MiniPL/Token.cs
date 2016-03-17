namespace MiniPL
{
    public sealed class Token
    {
        private readonly string text;
        private readonly TokenID id;

        public Token(string Text, TokenID Id)
        {
            text = Text;
            id = Id;
        }

        public override string ToString()
        {
            return id + ": "+ text;
        }
    }

    public enum TokenID
    {
        Identifier,
        Variable,
        IntegerLiteral,
        Colon,
        Assigment,
        Addition,
        Multiplication,
        ClosureOpen,
        ClosureClose,
        SemiColon,
        IntegerType,
        PrintProcedure
    }
}
