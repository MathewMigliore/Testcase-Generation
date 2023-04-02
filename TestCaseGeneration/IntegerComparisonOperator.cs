namespace TestCaseGenerator
{
    public class IntegerComparisonOperator
    {
        public bool IsEquals { get; }
        public bool IsGreaterThan { get; }
        public bool IsLessThan { get; }
        public IntegerComparisonOperator(string integerComparisonOperator)
        {
            IsEquals = integerComparisonOperator == "=";
            IsGreaterThan = integerComparisonOperator == ">";
            IsLessThan = integerComparisonOperator == "<";
        }
    }
}

