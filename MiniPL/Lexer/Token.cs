namespace MiniPL.Lexer
{
    public sealed class Token
    {
        public Symbol Symbol { get; }
        public string Value { get; }

        public Token(string Value, Symbol Symbol)
        {
            this.Value = Value;
            this.Symbol = Symbol;
        }
    }
}
