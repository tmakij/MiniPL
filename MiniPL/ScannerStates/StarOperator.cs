namespace MiniPL.ScannerStates
{
    public sealed class StarOperator : IScannerState
    {
        ScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (Read == '/')
            {
                return ScannerState.Comment;
            }
            //multiplication
            Current.End();
            return States.Get(ScannerState.Base).Read(Current,Read,States);
        }
    }
}
