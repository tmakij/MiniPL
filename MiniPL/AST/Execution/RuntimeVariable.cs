﻿namespace MiniPL.AST
{
    public sealed class RuntimeVariable
    {
        public MiniPLType Type { get; }
        public object Value { get; set; }

        public RuntimeVariable(MiniPLType Type)
        {
            this.Type = Type;
        }
    }
}
