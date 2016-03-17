namespace MiniPL.ScannerStates
{
    public sealed class StateStorage
    {
        public IScannerState Base { get; } = new Base();
        public IScannerState CommentStart { get; } = new CommentStart();
        public IScannerState Comment { get; } = new Comment();
        public IScannerState CommentEnd { get; } = new CommentEnd();
        public IScannerState Identifier { get; } = new Identifier();
        public IScannerState VariableV { get; } = new VariableV();
        public IScannerState VariableA { get; } = new VariableA();
        public IScannerState VariableR { get; } = new VariableR();
        public IScannerState Colon { get; } = new Colon();
        public IScannerState IntegerLiteral { get; } = new IntegerLiteral();
        public IScannerState IntegerI { get; } = new IntegerI();
        public IScannerState IntegerN { get; } = new IntegerN();
        public IScannerState IntegerT { get; } = new IntegerT();
        public IScannerState PrintP { get; }
        public IScannerState PrintR { get; }
        public IScannerState PrintI { get; }
        public IScannerState PrintN { get; }
        public IScannerState PrintT { get; } = new PrintT();

        public StateStorage()
        {
            PrintN = new PrintX('t', PrintT);
            PrintI = new PrintX('n', PrintN);
            PrintR = new PrintX('i', PrintI);
            PrintP = new PrintX('r', PrintR);
        }
    }
}
