namespace MiniPL.AST
{
    public sealed class StringConcatenation : IBinaryOperator
    {
        public object Execute(object FirstOperand, object SecondOperand)
        {
            return FirstOperand.ToString() + SecondOperand.ToString();
        }
    }
}
