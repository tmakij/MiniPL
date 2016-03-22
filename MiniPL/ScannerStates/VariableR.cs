namespace MiniPL.ScannerStates
{
    public sealed class VariableR : IScannerState
    {
        IScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (!char.IsLetterOrDigit(Read))
            {
                Current.End(Symbol.Variable);
            }
            return States.Base.Read(Current, Read, States);
        }
    }
}
