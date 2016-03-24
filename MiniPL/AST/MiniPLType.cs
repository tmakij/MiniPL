using System.Collections.Generic;

namespace MiniPL.AST
{
    public sealed class MiniPLType
    {
        public static MiniPLType Integer { get; } = new MiniPLType("Integer");
        public static MiniPLType String { get; } = new MiniPLType("String");
        public static MiniPLType Boolean { get; } = new MiniPLType("Boolean");

        static MiniPLType()
        {
            Integer.AddOperator(OperatorType.Addition, new IntegerAddition());
            Integer.AddOperator(OperatorType.Multiplication, new IntegerMultiplication());
        }

        private readonly Dictionary<OperatorType, IBinaryOperator> operators = new Dictionary<OperatorType, IBinaryOperator>();
        private readonly string name;

        private MiniPLType(string Name)
        {
            name = Name;
        }

        private void AddOperator(OperatorType Type, IBinaryOperator Operator)
        {
            operators.Add(Type, Operator);
        }

        public object BinaryOperation(object First, object Second, OperatorType Operator)
        {
            return operators[Operator].Execute(First, Second);
        }

        public override string ToString()
        {
            return name;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            MiniPLType other = (MiniPLType)obj;
            return name == other.name;
        }
    }
}
