﻿using System;

namespace MiniPL.AST
{
    public sealed class IntegerFormatException : Exception
    {
        public string ParseAttempt { get; }

        public IntegerFormatException(string ParseAttempt)
        {
            this.ParseAttempt = ParseAttempt;
        }
    }
}
