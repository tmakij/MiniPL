namespace MiniPL.ScannerStates
{
    public sealed class StateStorage
    {
        public IScannerState Base { get; } = new Base();
        public IScannerState CommentStart { get; } = new CommentStart();
        public IScannerState Comment { get; } = new Comment();
        public IScannerState CommentEnd { get; } = new CommentEnd();
        public IScannerState Identifier { get; } = new Identifier();
        public IScannerState Colon { get; } = new Colon();
        public IScannerState IntegerLiteral { get; } = new IntegerLiteral();
        public IScannerState StringLiteral { get; } = new StringLiteral();
        public IScannerState Range { get; } = new DoublePeriod();

        public IScannerState In { get; } = new SingleState('n', new InN());
        public IScannerState IntegerEnd { get; } = new SingleStateEnd(Symbol.IntegerType);
        public IScannerState Print { get; }
        public IScannerState Variable { get; }
        public IScannerState Read { get; }
        public IScannerState For { get; }
        public IScannerState End { get; }
        public IScannerState Assert { get; }
        public IScannerState String { get; }
        public IScannerState Boolean { get; }
        public IScannerState Do { get; }

        public StateStorage()
        {
            Print = Scanner(Symbol.PrintProcedure, "print");
            Variable = Scanner(Symbol.Variable, "var");
            Read = Scanner(Symbol.ReadProcedure, "read");
            For = Scanner(Symbol.For, "for");
            End = Scanner(Symbol.End, "end");
            Assert = Scanner(Symbol.Assert, "assert");
            String = Scanner(Symbol.StringType, "string");
            Boolean = Scanner(Symbol.BooleanType, "bool");
            Do = Scanner(Symbol.Do, "do");
        }

        private static IScannerState Scanner(Symbol End, string Moves)
        {
            IScannerState curr = new SingleStateEnd(End);
            for (int i = Moves.Length - 1; i > 0; i--)
            {
                curr = new SingleState(Moves[i], curr);
            }
            return curr;
        }
    }
}
