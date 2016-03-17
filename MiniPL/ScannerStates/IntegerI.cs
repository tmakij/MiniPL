namespace MiniPL.ScannerStates
{
    public sealed class IntegerI : IScannerState
    {
        IScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (Read == 'n')
            {
                Current.Append(Read);
                return States.IntegerN;
            }
            return States.Identifier.Read(Current, Read, States);
        }
    }
}
