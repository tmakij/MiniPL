namespace MiniPL.ScannerStates
{
    public sealed class Base : IScannerState
    {
        IScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (char.IsLetter(Read))
            {
                Current.Append(Read);
                switch (Read)
                {
                    case 'f':
                        return States.Identifier;
                    case 'i':
                        /*int, in*/
                        return States.IntegerI;
                    case 'e':
                        return States.Identifier;
                    case 'p':
                        return States.PrintP;
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
                        return States.VariableV;
                    default:
                        return States.Identifier;
                }
            }
            if (char.IsNumber(Read))
            {
                Current.Append(Read);
                return States.IntegerLiteral;
            }
            if (Read == '/')
            {
                return States.CommentStart;
            }
            if (Read == ':')
            {
                return States.Colon;
            }
            if (Read == '+')
            {
                Current.End(TokenID.Addition);
                return this;
            }
            if (Read == '*')
            {
                Current.End(TokenID.Multiplication);
                return this;
            }
            if (Read == ';')
            {
                Current.End(TokenID.SemiColon);
                return this;
            }
            if (Read == '(')
            {
                Current.End(TokenID.ClosureOpen);
                return this;
            }
            if (Read == ')')
            {
                Current.End(TokenID.ClosureClose);
                return this;
            }
            if (char.IsWhiteSpace(Read))
            {
                return this;
            }
            throw new LexerException("Invalid character " + Read);
        }
    }
}
