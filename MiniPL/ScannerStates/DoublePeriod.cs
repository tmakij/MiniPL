namespace MiniPL.ScannerStates
{
    public sealed class DoublePeriod : IScannerState
    {
        IScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (Read == '.')
            {
                Current.End(Symbol.Range);
                return States.Base;
            }
            throw new LexerException("Invalid range operator, expected \".\" but " + Read + " was found");
        }
    }
}
