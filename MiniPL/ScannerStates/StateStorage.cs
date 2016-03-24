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
        public IScannerState Print { get; }
        public IScannerState Variable { get; }
        public IScannerState Integer { get; }

        public StateStorage()
        {
            IScannerState PrintT = new SingleStateEnd(Symbol.PrintProcedure);
            IScannerState PrintN = new SingleState('t', PrintT);
            IScannerState PrintI = new SingleState('n', PrintN);
            IScannerState PrintR = new SingleState('i', PrintI);
            Print = new SingleState('r', PrintR);


            IScannerState VariableR = new SingleStateEnd(Symbol.Variable);
            IScannerState VariableA = new SingleState('r', VariableR);
            Variable = new SingleState('a', VariableA);

            IScannerState IntegerT = new SingleStateEnd(Symbol.IntegerType);
            IScannerState IntegerN = new SingleState('t', IntegerT);
            Integer = new SingleState('n', IntegerN);
        }
    }
}
