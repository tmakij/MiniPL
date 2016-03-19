using System.Collections.Generic;
using MiniPL.ScannerStates;

namespace MiniPL
{
    public sealed class Scanner
    {
        private readonly SourceStream source;

        public Scanner(SourceStream Source)
        {
            source = Source;
        }

        public IList<Token> GenerateTokens()
        {
            StateStorage scannerStates = new StateStorage();
            TokenConstruction constr = new TokenConstruction();
            IScannerState currentState = scannerStates.Base;
            while (true)
            {
                source.MoveNext();
                if (source.EndOfStream)
                {
                    break;
                }
                char curr = source.Current;
                currentState = currentState.Read(constr, curr, scannerStates);
            }
            constr.End(Symbol.EndOfInput);
            return constr.Tokens;
        }
    }
}
