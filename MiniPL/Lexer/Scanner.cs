﻿using MiniPL.Lexer.ScannerStates;

namespace MiniPL.Lexer
{
    public sealed class Scanner
    {
        private readonly SourceStream source;

        public Scanner(SourceStream Source)
        {
            source = Source;
        }

        public TokenStream GenerateTokens()
        {
            StateStorage scannerStates = new StateStorage();
            TokenConstruction constr = new TokenConstruction();
            IScannerState currentState = scannerStates.Base;
            do
            {
                char curr = source.Current;
                currentState = currentState.Read(constr, curr, scannerStates);
                source.MoveNext();
            } while (!source.EndOfStream);
            if (!currentState.Equals(scannerStates.Base))
            {
                throw new LexerException("Unexpected end of input");
            }
            constr.End(Symbol.EndOfInput);
            return constr.CreateStream();
        }
    }
}
