namespace MiniPL.AST
{
    public sealed class AbstractSyntaxTree
    {
        private readonly ScopedProgram statements;

        public AbstractSyntaxTree(ScopedProgram Statements)
        {
            statements = Statements;
        }

        public void CheckIdentifiers()
        {
            UsedIdentifiers identifiers = new UsedIdentifiers();
            statements.CheckIdentifiers(identifiers);
        }

        public void CheckTypes()
        {
            IdentifierTypes types = new IdentifierTypes();
            statements.CheckTypes(types);
        }

        public void Execute()
        {
            Variables globalScope = new Variables();
            statements.Execute(globalScope);
        }
    }
}
