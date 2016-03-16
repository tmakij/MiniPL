using System.Collections.Generic;
using MiniPL.ScannerStates;

namespace MiniPL
{
    public sealed class Scanner
    {
        private readonly List<Token> tokens = new List<Token>();
        private readonly StateStorage scannerStates = new StateStorage();
        private readonly SourceStream source;

        public Scanner(SourceStream Source)
        {
            source = Source;
        }

        public IList<Token> Tokens { get { return tokens.AsReadOnly(); } }

        public void GenerateTokens()
        {
            TokenConstruction constr = new TokenConstruction();
            IScannerState currentState = scannerStates.Get(ScannerState.Base);
            while (true)
            {
                source.MoveNext();
                if (source.EndOfStream)
                {
                    break;
                }
                char curr = source.Current;
                ScannerState newState = currentState.Read(constr, curr, scannerStates);
                currentState = scannerStates.Get(newState);
            }
        }
    }
}
