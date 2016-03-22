namespace MiniPL.AST
{
    public sealed class DeclarationStatement : IStatement
    {
        private readonly VariableIdentifier identifier;
        private readonly IType type;
        private readonly IExpression optionalAssigment;

        public DeclarationStatement(VariableIdentifier Identifier, IType Type, IExpression OptionalAssigment)
        {
            identifier = Identifier;
            type = Type;
            optionalAssigment = OptionalAssigment;
        }
    }
}
