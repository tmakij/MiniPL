namespace MiniPL.Parser.AST
{
    public sealed class VariableIdentifier
    {
        private readonly string name;

        public VariableIdentifier(string Name)
        {
            name = Name;
        }

        public override string ToString()
        {
            return name;
        }

        public override bool Equals(object obj)
        {
            VariableIdentifier identifier = (VariableIdentifier)obj;
            return identifier.name == name;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }
    }
}
