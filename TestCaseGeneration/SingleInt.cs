using System.Text.RegularExpressions;
using static TestCaseGenerator.RegexConstants;
namespace TestCaseGenerator
{
    public class GroupInteger
    {
        public bool IntegerOperatorSuccess { get; }
        public IntegerComparisonOperator IntegerComparisonOperator { get; }
        public int IntegerValue { get; }
        public bool IntegerRangeSuccess { get; }
        public int IntegerRangeFirstValue { get; }
        public int IntegerRangeSecondValue { get; }
        public bool IncrementSuccess { get; }
        public IncrementOperator IncrementOperator { get; }
        public int IncrementValue { get; }
        public bool OrderSuccess { get; }
        public Order Order { get; }
        public bool QuantityOfTestCasesSuccess { get; }
        public int QuantityOfTestCases { get; }

        public GroupInteger(Match match)
        {
            IntegerOperatorSuccess = match.Groups[GROUP_INTEGER_OPERATOR].Success;
            if (IntegerOperatorSuccess)
            {
                IntegerComparisonOperator = new IntegerComparisonOperator(match.Groups[INTEGER_COMPARISON_OPERATOR].Value);
                IntegerValue = int.Parse(match.Groups[INTEGER_VALUE].Value);
                
            }
            else {
                IntegerRangeSuccess = match.Groups[GROUP_INTEGER_RANGE].Success;
                if (IntegerRangeSuccess)
                {
                    IntegerRangeFirstValue = int.Parse(match.Groups[INTEGER_RANGE_FIRST_VALUE].Value);
                    IntegerRangeSecondValue = int.Parse(match.Groups[INTEGER_RANGE_SECOND_VALUE].Value);
                    
                }
            }

            IncrementSuccess = match.Groups[GROUP_INCREMENT].Success;
            if (IncrementSuccess)
            {
                IncrementOperator = new IncrementOperator(match.Groups[INCREMENT_OPERATOR].Value);
                IncrementValue = int.Parse(match.Groups[INCREMENT_VALUE].Value);
                
            }

            OrderSuccess = match.Groups[ORDER].Success;
            if (match.Groups[ORDER].Success)
            {
                Order = new Order(match.Groups[ORDER].Value);
                
            } 

            QuantityOfTestCasesSuccess = match.Groups[QUANTITY_OF_TEST_CASES].Success;
            if (match.Groups[QUANTITY_OF_TEST_CASES].Success)
            {
                QuantityOfTestCases = int.Parse(match.Groups[QUANTITY_OF_TEST_CASES].Value);
            }
        }
        

    }
    public class Order
    {
        public bool Ascending { get; }
        public bool Descending { get; }
        public Order(string orderValue)
        {
            Ascending = orderValue == "asc";
            Descending = orderValue == "desc";
        }
    }

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

    public class IncrementOperator
    {
        public bool IsPlus { get; }
        public bool IsMinus { get; }
        public bool IsMultiply { get; }
        public bool IsDivide { get; }
        public IncrementOperator(string incrementOperator)
        {
            IsPlus = incrementOperator == "+";
            IsMinus = incrementOperator == "-";
            IsMultiply = incrementOperator == "*";
            IsDivide = incrementOperator == "/";
        }
    }
}

