namespace MiniPL.AST
{
    public interface IAstNode : IIDentifierHolder
    {
        MiniPLType NodeType(IdentifierTypes Types);
    }
}
