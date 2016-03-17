namespace MiniPL.ScannerStates
{
    public sealed class Identifier : IScannerState
    {
        public static bool IsAcceptableIdentifier(char Character)
        {
            return char.IsLetterOrDigit(Character) || Character == '_';
        }

        IScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            /*if (char.IsWhiteSpace(Read))
            {
                Current.End();
                return States.Base;
            }*/
            if (IsAcceptableIdentifier(Read))
            {
                Current.Append(Read);
                return States.Identifier;
            }
            Current.End();
            return States.Base.Read(Current, Read, States);
            //throw new LexerException("Invalid indentifier character \"" + CharToString.Convert(Read) + "\", expected [A-Za-z0-9_]");
        }
    }
}
