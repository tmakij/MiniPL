namespace MiniPL.AST
{
    public sealed class AssigmentStatement : IStatement
    {
        private readonly VariableIdentifier identifier;
        private readonly IExpression expression;

        public AssigmentStatement(VariableIdentifier Identifier, IExpression Expression)
        {
            identifier = Identifier;
            expression = Expression;
        }
    }
}
