namespace MiniPL.ScannerStates
{
    public sealed class CommentEnd : IScannerState
    {
        ScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (Read == '/')
            {
                return ScannerState.Base;
            }
            return ScannerState.Comment;
        }
    }
}
