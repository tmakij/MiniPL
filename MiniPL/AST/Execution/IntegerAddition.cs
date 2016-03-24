namespace MiniPL.AST
{
    public sealed class IntegerAddition : IBinaryOperator
    {
        public object Execute(object FirstOperand, object SecondOperand)
        {
            int val1 = (int)FirstOperand;
            int val2 = (int)SecondOperand;
            int res = val1 + val2;
            return res;
        }
    }
}
