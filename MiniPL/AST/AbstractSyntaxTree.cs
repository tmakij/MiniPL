using System.Collections.Generic;

namespace MiniPL.AST
{
    public sealed class AbstractSyntaxTree
    {
        private readonly IList<IStatement> statements;

        public AbstractSyntaxTree(IList<IStatement> Statements)
        {
            statements = Statements;
        }

        public void CheckIdentifiers()
        {
            UsedIdentifiers identifiers = new UsedIdentifiers();
            foreach (IStatement item in statements)
            {
                item.CheckIdentifiers(identifiers);
            }
        }

        public void CheckTypes()
        {
            IdentifierTypes types = new IdentifierTypes();
            foreach (IStatement item in statements)
            {
                item.CheckType(types);
            }
        }
    }
}
