namespace MiniPL
{
    public sealed class Token
    {
        public Symbol Symbol { get; }
        private readonly string text;

        public Token(string Text, Symbol Symbol)
        {
            text = Text;
            this.Symbol = Symbol;
        }

        public override string ToString()
        {
            return Symbol + ": "+ text;
        }
    }
}
