namespace MiniPL.ScannerStates
{
    public sealed class StateStorage
    {
        public Base Base { get; }
        public StarOperator StarOperator { get; }
        public Commment Commment { get; }
        public CommentEnd CommentEnd { get; }
        public Identifier Identifier { get; }
        public VariableV VariableV { get; }
        public VariableA VariableA { get; }
        public VariableR VariableR { get; }
        public Colon Colon { get; }
        public IntegerLiteral IntegerLiteral { get; }

        private readonly IScannerState[] states;

        public StateStorage()
        {
            states = new IScannerState[]
            {
                new Base(),
                new StarOperator(),
                new Commment(),
                new CommentEnd(),
                new Identifier(),
                new VariableV(),
                new VariableA(),
                new VariableR(),
                new Colon(),
                new IntegerLiteral()
            };
            Base = new Base();
            StarOperator = new StarOperator();
            Commment = new Commment();
            CommentEnd = new CommentEnd();
            Identifier = new Identifier();
            VariableV = new VariableV();
            VariableA = new VariableA();
            VariableR = new VariableR();
            Colon = new Colon();
            IntegerLiteral = new IntegerLiteral();
        }

        public IScannerState Get(ScannerState State)
        {
            return states[(int)State];
        }
    }
}
