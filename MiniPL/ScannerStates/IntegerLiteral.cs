namespace MiniPL.ScannerStates
{
    public sealed class IntegerLiteral : IScannerState
    {
        IScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (char.IsNumber(Read))
            {
                Current.Append(Read);
                return States.IntegerLiteral;
            }
            Current.End(TokenID.IntegerLiteral);
            return States.Base.Read(Current, Read, States);
        }
    }
}
