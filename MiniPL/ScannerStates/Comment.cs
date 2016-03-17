﻿namespace MiniPL.ScannerStates
{
    public sealed class Comment : IScannerState
    {
        IScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (Read == '*')
            {
                return States.CommentEnd;
            }
            return States.Comment;
        }
    }
}
