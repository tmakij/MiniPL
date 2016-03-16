namespace MiniPL.ScannerStates
{
    public sealed class Identifier : IScannerState
    {
        public static bool IsAcceptableIdentifier(char Character)
        {
            return char.IsLetterOrDigit(Character) || Character == '_';
        }

        ScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (char.IsWhiteSpace(Read))
            {
                Current.End();
                return ScannerState.Base;
            }
            if (IsAcceptableIdentifier(Read))
            {
                Current.Append(Read);
                return ScannerState.Identifier;
            }
            throw new LexerException("Invalid indentifier character \"" + CharToString.Convert(Read) + "\", expected [A-Za-z0-9_]");
        }
    }
}
