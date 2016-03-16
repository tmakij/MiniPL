namespace MiniPL.ScannerStates
{
    public sealed class VariableR : IScannerState
    {
        ScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (char.IsWhiteSpace(Read))
            {
                Current.End();
                return ScannerState.Base;
            }
            return States.Get(ScannerState.Identifier).Read(Current, Read, States);
            /*if (Identifier.IsAcceptableIdentifier(Read))
            {
                Current.Append(Read);
                return ScannerState.Identifier;
            }
            throw new LexerException("Expected the keyword \"var\" or a valid identifier [A-Za-z0-9_], \"" + CharToString.Convert(Read) + "\" found");*/
        }
    }
}
