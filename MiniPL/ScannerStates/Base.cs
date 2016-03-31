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
                        return States.For;
                    case 'i':
                        /*int, in*/
                        return States.In;
                    case 'e':
                        return States.End;
                    case 'p':
                        return States.Print;
                    case 'd':
                        return States.Do;
                    case 'r':
                        return States.Read;
                    case 's':
                        return States.String;
                    case 'b':
                        return States.Boolean;
                    case 'a':
                        return States.Assert;
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
                    return States.ForwardSlash;
                case ':':
                    return States.Colon;
                case '"':
                    return States.StringLiteral;
                case '.':
                    return States.Range;
                case '&':
                    Current.End(Symbol.LogicalAnd);
                    return this;
                case '!':
                    Current.End(Symbol.LogicalNot);
                    return this;
                case '<':
                    Current.End(Symbol.LessThan);
                    return this;
                case '=':
                    Current.End(Symbol.Equality);
                    return this;
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
                case '-':
                    Current.End(Symbol.Substraction);
                    return this;
            }
            throw new LexerException("Invalid character " + Read);
        }
    }
}
