namespace MiniPL.AST
{
    public sealed class BooleanNegation : IUnaryOperator
    {
        public object Execute(object Operand)
        {
            bool val = (bool)Operand;
            return !val;
        }
    }
}
