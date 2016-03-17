﻿namespace MiniPL.ScannerStates
{
    public sealed class VariableV : IScannerState
    {
        IScannerState IScannerState.Read(TokenConstruction Current, char Read, StateStorage States)
        {
            if (Read == 'a')
            {
                Current.Append(Read);
                return States.VariableA;
            }
            return States.Identifier.Read(Current, Read, States);
        }
    }
}