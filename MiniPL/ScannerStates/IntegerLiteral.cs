namespace MiniPL.ScannerStates
{
    public sealed class IntegerLiteral : IScannerState
    {
        ScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (char.IsNumber(Read))
            {
                Current.Append(Read);
                return ScannerState.IntergerLiteral;
            }
            if (char.IsWhiteSpace(Read))
            {
                Current.End();
                return ScannerState.Base;
            }
            throw new LexerException("Expected integer, " + CharToString.Convert(Read) + " was found");
        }
    }
}
