using System.Collections.Generic;

namespace MiniPL
{
    public sealed class SyntaxNode
    {
        public Symbol Symbol { get; }
        public List<SyntaxNode> Children { get; } = new List<SyntaxNode>();

        public SyntaxNode(Symbol Symbol)
        {
            this.Symbol = Symbol;
        }

        public void Add(SyntaxNode ToAdd)
        {
            Children.Add(ToAdd);
        }
    }
}
