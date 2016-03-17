namespace MiniPL.ScannerStates
{
    public sealed class VariableA : IScannerState
    {
        IScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (Read == 'r')
            {
                Current.Append(Read);
                return States.VariableR;
            }
            return States.Identifier.Read(Current, Read, States);
        }
    }
}
