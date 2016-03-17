namespace MiniPL.ScannerStates
{
    public sealed class IntegerT : IScannerState
    {
        IScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (char.IsWhiteSpace(Read))
            {
                Current.End(TokenID.IntegerType);
                return States.Base;
            }
            return States.Identifier.Read(Current, Read, States);
        }
    }
}
