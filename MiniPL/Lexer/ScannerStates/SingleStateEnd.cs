namespace MiniPL.Lexer.ScannerStates
{
    public sealed class SingleStateEnd : IScannerState
    {
        private readonly Symbol endSymbol;

        public SingleStateEnd(Symbol EndSymbol)
        {
            endSymbol = EndSymbol;
        }

        IScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (!char.IsLetterOrDigit(Read))
            {
                Current.End(endSymbol);
            }
            return States.Base.Read(Current, Read, States);
        }
    }
}
