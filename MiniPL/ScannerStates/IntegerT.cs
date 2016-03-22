namespace MiniPL.ScannerStates
{
    public sealed class IntegerT : IScannerState
    {
        IScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (!char.IsLetterOrDigit(Read))
            {
                Current.End(Symbol.IntegerType);
            }
            return States.Base.Read(Current, Read, States);
        }
    }
}
