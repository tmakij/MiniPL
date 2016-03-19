namespace MiniPL.ScannerStates
{
    public sealed class PrintT : IScannerState
    {
        IScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (char.IsWhiteSpace(Read))
            {
                Current.End(Symbol.PrintProcedure);
                return States.Base;
            }
            return States.Identifier.Read(Current, Read, States);
        }
    }
}
