namespace MiniPL.ScannerStates
{
    public sealed class IntegerN : IScannerState
    {
        IScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (Read == 't')
            {
                Current.Append(Read);
                return States.IntegerT;
            }
            return States.Identifier.Read(Current, Read, States);
        }
    }
}
