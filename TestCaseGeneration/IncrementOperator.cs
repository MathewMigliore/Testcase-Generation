namespace TestCaseGenerator
{
    public class Operator
    {
        public bool IsPlus { get; }
        public bool IsMinus { get; }
        public bool IsMultiply { get; }
        public bool IsDivide { get; }
        public Operator(string incrementOperator)
        {
            IsPlus = incrementOperator == "+";
            IsMinus = incrementOperator == "-";
            IsMultiply = incrementOperator == "*";
            IsDivide = incrementOperator == "/";
        }
    }
}

