namespace MiniPL.AST
{
    public sealed class DeclarationStatement : IStatement
    {
        private readonly VariableIdentifier identifier;
        private readonly MiniPLType type;
        private readonly IExpression optionalAssigment;

        public DeclarationStatement(VariableIdentifier Identifier, MiniPLType Type, IExpression OptionalAssigment)
        {
            identifier = Identifier;
            type = Type;
            optionalAssigment = OptionalAssigment;
        }

        public void CheckIdentifiers(UsedIdentifiers Used)
        {
            if (Used.IsUsed(identifier))
            {
                throw new VariableNameDefinedException(identifier);
            }
            optionalAssigment.CheckIdentifiers(Used);
        }

        public void CheckType(IdentifierTypes Types)
        {
            Types.SetIdentifierType(identifier, type);
            MiniPLType assigmentType = optionalAssigment.NodeType(Types);
            if (!assigmentType.Equals(type))
            {
                throw new TypeMismatchException(type, assigmentType);
            }
        }
    }
}
