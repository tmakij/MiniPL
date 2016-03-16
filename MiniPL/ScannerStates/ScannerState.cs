namespace MiniPL.ScannerStates
{
    public enum ScannerState
    {
        Base,
        StarOperator,
        Comment,
        CommentEnd,
        Identifier,
        VariableV,
        VariableA,
        VariableR,
        Colon,
        IntergerLiteral
    }
}
