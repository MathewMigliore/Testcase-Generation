using System.Text.RegularExpressions;
using static TestCaseGenerator.RegexConstants;
namespace TestCaseGenerator
{
    public class GroupInteger
    {
        public IntegerComparisonOperator IntegerComparisonOperator 
        { 
            get => _integerComparisonOperator;
            private set { _integerComparisonOperator = value; }
        }
        public int IntegerValue 
        { 
            get => _integerValue;
            private set { _integerValue = value; }
        }
        public int IntegerRangeFirstValue 
        { 
            get => _integerRangeFirstValue;
            private set { _integerRangeFirstValue = value; }
        }
        public int IntegerRangeSecondValue 
        { 
            get => _integerRangeSecondValue;
            private set { _integerRangeSecondValue = value; }
        }
        public Operator IncrementOperator 
        { 
            get => _incrementOperator;
            private set { _incrementOperator = value; }
        }
        public int IncrementValue 
        { 
            get => _incrementValue; 
            private set { _incrementValue = value; }
        }
        public Order Order 
        { 
            get => _order; 
            private set { _order = value; }
        }        
        public int QuantityOfTestCases 
        { 
            get { return _quantityOfTestCases; } 
            private set { _quantityOfTestCases = value; }
        }    



        private IntegerComparisonOperator _integerComparisonOperator;
        private int _integerValue;
        private int _integerRangeFirstValue;
        private int _integerRangeSecondValue;
        private Operator _incrementOperator;
        private int _incrementValue;
        private Order _order;
        private int _quantityOfTestCases;


        public bool IntegerOperatorSuccess { get; }
        public bool IntegerRangeSuccess { get; }
        public bool IncrementSuccess { get; }
        public bool OrderSuccess { get; }
        public bool QuantityOfTestCasesSuccess { get; }


        public GroupInteger(Match match)
        {
            if (IntegerOperatorSuccess = match.Groups[GROUP_INTEGER_OPERATOR].Success)
                ValidateGroupIntegerOperator(match);
                
            if (IntegerRangeSuccess = match.Groups[GROUP_INTEGER_RANGE].Success)
                ValidateGroupIntegerRange(match);

            if (IncrementSuccess = match.Groups[GROUP_INCREMENT].Success)
                ValidateGroupIncrement(match);

            if (OrderSuccess = match.Groups[ORDER].Success)
                ValidateOrder(match);

            if (QuantityOfTestCasesSuccess = match.Groups[QUANTITY_OF_TEST_CASES].Success)
                ValidateQuantityOfCases(match);
            else
                QuantityOfTestCases = 10;

            if (IntegerRangeSuccess && IncrementSuccess)
                ValidateIntegerRangeWithIncrement(match);
        }
        private void ValidateIntegerRangeWithIncrement(Match match)
        {
            
            
            if (IncrementOperator.IsPlus)
            {
                if (IntegerRangeFirstValue > IntegerRangeSecondValue)
                    throw new Exception("Invalid integer range: first value must be less than or equal to the second value");
            }
            else if (IncrementOperator.IsMinus)
            {
                if (IntegerRangeFirstValue < IntegerRangeSecondValue)
                    throw new Exception("Invalid integer range: first value must be greater than or equal to the second value");
            }
            else if (IncrementOperator.IsMultiply)
            {
                if (IncrementValue == 0)
                    throw new Exception("Invalid integer value: 0");
                if (!((IntegerRangeFirstValue > 0 && IncrementValue > 0) || (IntegerRangeFirstValue < 0 && IncrementValue < 0))) // If one but not both are negative
                    if (IntegerRangeFirstValue > IntegerRangeSecondValue)
                        throw new Exception("Invalid integer range: both values must be negative or positive");
            }
            else if (IncrementOperator.IsDivide)
            {
                if (IncrementValue == 0)
                    throw new Exception("Invalid integer value: cannot divide by 0");
                if (!((IntegerRangeFirstValue > 0 && IncrementValue > 0) || (IntegerRangeFirstValue < 0 && IncrementValue < 0)))
                    if (IntegerRangeFirstValue < IntegerRangeSecondValue)
                        throw new Exception("Invalid integer range: You cannot divide an integer and get a larger integer");
            }
        }
        private void ValidateQuantityOfCases(Match match)
        {
            if (!int.TryParse(match.Groups[QUANTITY_OF_TEST_CASES].Value, out int quantityOfTestCases))
                throw new Exception("Invalid quantity of test cases: must be a number");
            
            if (quantityOfTestCases < 1)
                throw new Exception("Invalid quantity of test cases: must be greater than 0");

            QuantityOfTestCases = quantityOfTestCases;
        }

        private void ValidateOrder(Match match)
        {
            if (string.IsNullOrEmpty(match.Groups[ORDER].Value.ToString()))
                throw new Exception("Invalid order: must not be null or empty");
            
            if (match.Groups[ORDER].Value != "asc" && match.Groups[ORDER].Value != "desc")
                throw new Exception("Invalid order: must be asc or desc");
            
            Order = new Order(match.Groups[ORDER].Value);
        }

        private void ValidateGroupIncrement(Match match)
        {
            ValidateIncrementOperator(match);
            ValidateIncrementValue(match);
        }

        private void ValidateIncrementValue(Match match)
        {
            if (!int.TryParse(match.Groups[INCREMENT_VALUE].Value, out int incrementValue))
                throw new Exception("Invalid increment value: must be a number");
            
            IncrementValue = int.Parse(match.Groups[INCREMENT_VALUE].Value);
        }

        private void ValidateIncrementOperator(Match match)
        {
            if (string.IsNullOrEmpty(match.Groups[INCREMENT_OPERATOR].Value.ToString()))
                throw new Exception("Invalid increment operator: must not be null or empty");

            IncrementOperator = new Operator(match.Groups[INCREMENT_OPERATOR].Value);
        }

        private void ValidateGroupIntegerRange(Match match)
        {
            if (!int.TryParse(match.Groups[INTEGER_RANGE_FIRST_VALUE].Value, out int integerRangeFirstValue))
                throw new Exception("Invalid integer range first value: must be a number");
            if (!int.TryParse(match.Groups[INTEGER_RANGE_SECOND_VALUE].Value, out int integerRangeSecondValue))
                throw new Exception("Invalid integer range second value: must be a number");
            
            IntegerRangeFirstValue = integerRangeFirstValue;
            IntegerRangeSecondValue = integerRangeSecondValue;
        }

        private void ValidateGroupIntegerOperator(Match match)
        {
            ValidateIntegerComparisonOperator(match);
            ValidateIntegerValue(match);
        }

        private void ValidateIntegerComparisonOperator(Match match)
        {
            if (string.IsNullOrEmpty(match.Groups[INTEGER_COMPARISON_OPERATOR].Value.ToString()))
                throw new Exception("Invalid integer comparison operator: must not be null or empty");

            IntegerComparisonOperator = new IntegerComparisonOperator(match.Groups[INTEGER_COMPARISON_OPERATOR].Value);
        }

        private void ValidateIntegerValue(Match match)
        {
            if (!int.TryParse(match.Groups[INTEGER_VALUE].Value, out int integerValue))
                throw new Exception("Invalid integer value: must be a number");
            IntegerValue = integerValue;
        }
    }

}

