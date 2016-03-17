namespace MiniPL.ScannerStates
{
    public sealed class Colon : IScannerState
    {
        IScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (Read == '=')
            {
                Current.End(TokenID.Assigment);
                return States.Base;
            }
            Current.End(TokenID.Colon);
            return States.Base.Read(Current, Read, States);
        }
    }
}
