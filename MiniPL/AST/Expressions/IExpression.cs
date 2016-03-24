namespace MiniPL.AST
{
    public interface IExpression : IAstNode
    {
        ReturnValue Execute(Variables Global);
    }
}
