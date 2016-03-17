namespace MiniPL.ScannerStates
{
    public sealed class CommentStart : IScannerState
    {
        IScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (Read == '*')
            {
                return States.Comment;
            }
            throw new LexerException("Invalid comment start, expected \"*\" but found \"" + Read + "\"");
        }
    }
}
