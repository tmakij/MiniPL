namespace MiniPL.ScannerStates
{
    public sealed class Base : IScannerState
    {
        ScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (char.IsLetter(Read))
            {
                Current.Append(Read);
                switch (Read)
                {
                    case 'f':
                        return ScannerState.Identifier;
                    case 'i':
                        /*int, in*/
                        return ScannerState.Identifier;
                    case 'e':
                        return ScannerState.Identifier;
                    case 'p':
                        return ScannerState.Identifier;
                    case 'd':
                        return ScannerState.Identifier;
                    case 'r':
                        return ScannerState.Identifier;
                    case 's':
                        return ScannerState.Identifier;
                    case 'b':
                        return ScannerState.Identifier;
                    case 'a':
                        return ScannerState.Identifier;
                    case 'v':
                        return ScannerState.VariableV;
                    default:
                        return ScannerState.Identifier;
                }
            }
            if (char.IsNumber(Read))
            {
                Current.Append(Read);
                return ScannerState.IntergerLiteral;
            }
            if (Read == '*')
            {
                return ScannerState.StarOperator;
            }
            if (Read == ':')
            {
                Current.Append(Read);
                return ScannerState.Colon;
            }
            if (char.IsWhiteSpace(Read))
            {
                return ScannerState.Base;
            }
            throw new LexerException("Invalid character " + Read);
        }
    }
}
