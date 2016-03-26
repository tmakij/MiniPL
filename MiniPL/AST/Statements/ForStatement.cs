namespace MiniPL.AST
{
    public sealed class ForStatement : IStatement
    {
        private readonly VariableIdentifier iterator;
        private readonly IExpression lowBound, highBound;
        private readonly ScopedProgram toExecute;

        public ForStatement(VariableIdentifier Iterator, IExpression LowBound, IExpression HighBound, ScopedProgram ToExecute)
        {
            iterator = Iterator;
            lowBound = LowBound;
            highBound = HighBound;
            toExecute = ToExecute;
        }

        public void CheckIdentifiers(UsedIdentifiers Used)
        {
            if (!Used.IsUsed(iterator))
            {
                throw new UninitializedVariableException(iterator);
            }
            lowBound.CheckIdentifiers(Used);
            highBound.CheckIdentifiers(Used);
            toExecute.CheckIdentifiers(Used);
        }

        public void CheckType(IdentifierTypes Types)
        {
            MiniPLType iteratorType = Types.GetIdentifierType(iterator);
            if (!iteratorType.Equals(MiniPLType.Integer))
            {
                throw new TypeMismatchException(MiniPLType.Integer, iteratorType);
            }
            MiniPLType lowBoundType = lowBound.NodeType(Types);
            if (!lowBoundType.Equals(MiniPLType.Integer))
            {
                throw new TypeMismatchException(MiniPLType.Integer, lowBoundType);
            }
            MiniPLType highBoundType = highBound.NodeType(Types);
            if (!highBoundType.Equals(MiniPLType.Integer))
            {
                throw new TypeMismatchException(MiniPLType.Integer, highBoundType);
            }
            toExecute.CheckTypes(Types);
        }

        public void Execute(Variables Scope)
        {
            RuntimeVariable itr = Scope.GetValue(iterator);
            ReturnValue low = lowBound.Execute(Scope);
            ReturnValue high = highBound.Execute(Scope);
            int start = (int)low.Value;
            int end = (int)high.Value;
            for (int i = start; i < end; i++)
            {
                itr.Value = i;
                toExecute.Execute(Scope);
            }
        }
    }
}
