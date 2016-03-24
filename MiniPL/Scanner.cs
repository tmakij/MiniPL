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
            constr.End(Symbol.EndOfInput);
            return constr.CreateStream();
        }
    }
}
