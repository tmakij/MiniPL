﻿namespace MiniPL.ScannerStates
{
    public sealed class CommentEnd : IScannerState
    {
        IScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (Read == '/')
            {
                return States.Base;
            }
            return States.Comment;
        }
    }
}