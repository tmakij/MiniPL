namespace MiniPL.AST
{
    public interface IOperand : IAstNode
    {
        ReturnValue Execute(Variables Global);
    }
}
