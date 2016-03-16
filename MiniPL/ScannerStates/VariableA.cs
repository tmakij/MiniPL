namespace MiniPL.ScannerStates
{
    public sealed class VariableA : IScannerState
    {
        ScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (Read == 'r')
            {
                Current.Append(Read);
                return ScannerState.VariableR;
            }
            return States.Get(ScannerState.Identifier).Read(Current, Read, States);
            /*if (Identifier.IsAcceptableIdentifier(Read))
            {
                Current.Append(Read);
                return ScannerState.Identifier;
            }
            if (char.IsWhiteSpace(Read))
            {
                Current.End();
                return ScannerState.Base;
            }
            throw new LexerException("Expected the keyword \"var\" or a valid identifier [A-Za-z0-9_], \"" + CharToString.Convert(Read) + "\" found");*/
        }
    }
}
