namespace MiniPL.AST
{
    public interface IBinaryOperator
    {
        object Execute(object FirstOperand, object SecondOperand);
    }
}
