namespace MiniPL.ScannerStates
{
    public sealed class InN : IScannerState
    {
        IScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (!char.IsLetterOrDigit(Read))
            {
                Current.End(Symbol.In);
                return States.Base.Read(Current, Read, States);
            }
            if (Read == 't')
            {
                return States.IntegerEnd;
            }
            return States.Identifier.Read(Current, Read, States);
        }
    }
}
