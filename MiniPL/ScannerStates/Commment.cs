namespace MiniPL.ScannerStates
{
    public sealed class Commment : IScannerState
    {
        ScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (Read == '*')
            {
                return ScannerState.CommentEnd;
            }
            return ScannerState.Comment;
        }
    }
}
