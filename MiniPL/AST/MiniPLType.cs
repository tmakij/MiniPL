using System.Collections.Generic;

namespace MiniPL.AST
{
    public sealed class MiniPLType
    {
        public static MiniPLType Integer { get; } = new MiniPLType("Integer", 0);
        public static MiniPLType String { get; } = new MiniPLType("String", string.Empty);
        public static MiniPLType Boolean { get; } = new MiniPLType("Boolean", false);

        static MiniPLType()
        {
            Integer.AddBinaryOperator(OperatorType.Addition, new IntegerAddition());
            Integer.AddBinaryOperator(OperatorType.Multiplication, new IntegerMultiplication());
            Integer.AddBinaryOperator(OperatorType.Substraction, new IntegerSubstraction());
            Integer.AddBinaryOperator(OperatorType.Division, new IntegerDivision());
            String.AddBinaryOperator(OperatorType.Addition, new StringConcatenation());
            Boolean.AddUnaryOperator(OperatorType.Negation, new BooleanNegation());
        }

        public object DefaultValue { get; }
        private readonly Dictionary<OperatorType, IBinaryOperator> binaryOperators = new Dictionary<OperatorType, IBinaryOperator>();
        private readonly Dictionary<OperatorType, IUnaryOperator> unaryOperators = new Dictionary<OperatorType, IUnaryOperator>();
        private readonly string name;

        private MiniPLType(string Name, object DefaultValue)
        {
            name = Name;
            this.DefaultValue = DefaultValue;
        }

        private void AddBinaryOperator(OperatorType Type, IBinaryOperator Operator)
        {
            binaryOperators.Add(Type, Operator);
        }

        private void AddUnaryOperator(OperatorType Type, IUnaryOperator Operator)
        {
            unaryOperators.Add(Type, Operator);
        }

        public object BinaryOperation(object First, object Second, OperatorType Operator)
        {
            return binaryOperators[Operator].Execute(First, Second);
        }

        public object UnaryOperation(object Operand, OperatorType Operator)
        {
            return unaryOperators[Operator].Execute(Operand);
        }

        public bool HasOperatorDefined(OperatorType Operator)
        {
            return unaryOperators.ContainsKey(Operator) || binaryOperators.ContainsKey(Operator);
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
