namespace MiniPL.ScannerStates
{
    public sealed class VariableR : IScannerState
    {
        IScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (char.IsWhiteSpace(Read))
            {
                Current.End(TokenID.Variable);
                return States.Base;
            }
            return States.Identifier.Read(Current, Read, States);
        }
    }
}
