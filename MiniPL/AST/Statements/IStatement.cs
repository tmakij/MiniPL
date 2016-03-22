namespace MiniPL.AST
{
    public interface IStatement : IIDentifierHolder
    {
        void CheckType(IdentifierTypes Types);
    }
}
