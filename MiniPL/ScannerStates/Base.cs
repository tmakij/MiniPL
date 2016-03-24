namespace MiniPL.ScannerStates
{
    public sealed class Base : IScannerState
    {
        IScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (char.IsWhiteSpace(Read))
            {
                return this;
            }
            if (char.IsLetter(Read))
            {
                Current.Append(Read);
                switch (Read)
                {
                    case 'f':
                        return States.Identifier;
                    case 'i':
                        /*int, in*/
                        return States.Integer;
                    case 'e':
                        return States.Identifier;
                    case 'p':
                        return States.Print;
                    case 'd':
                        return States.Identifier;
                    case 'r':
                        return States.Identifier;
                    case 's':
                        return States.Identifier;
                    case 'b':
                        return States.Identifier;
                    case 'a':
                        return States.Identifier;
                    case 'v':
                        return States.Variable;
                    default:
                        return States.Identifier;
                }
            }
            if (char.IsNumber(Read))
            {
                Current.Append(Read);
                return States.IntegerLiteral;
            }
            switch (Read)
            {
                case '/':
                    return States.CommentStart;
                case ':':
                    return States.Colon;
                case '+':
                    Current.End(Symbol.Addition);
                    return this;
                case '*':
                    Current.End(Symbol.Multiplication);
                    return this;
                case ';':
                    Current.End(Symbol.SemiColon);
                    return this;
                case '(':
                    Current.End(Symbol.ClosureOpen);
                    return this;
                case ')':
                    Current.End(Symbol.ClosureClose);
                    return this;
            }
            throw new LexerException("Invalid character " + Read);
        }
    }
}
