namespace MiniPL.ScannerStates
{
    public sealed class Colon : IScannerState
    {
        ScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (Read == '=')
            {
                Current.Append(Read);
                Current.End();
                return ScannerState.Base;
            }
            Current.End();
            return States.Get(ScannerState.Base).Read(Current, Read, States);
        }
    }
}
