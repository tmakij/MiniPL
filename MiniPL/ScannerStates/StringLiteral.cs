namespace MiniPL.ScannerStates
{
    public sealed class StringLiteral : IScannerState
    {
        IScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (Read == '"')
            {
                Current.End(Symbol.StringLiteral);
                return States.Base;
            }
            Current.Append(Read);
            return this;
        }
    }
}
