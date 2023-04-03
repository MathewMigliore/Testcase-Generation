namespace TestCaseGenerator
{
    public static class CreateIntegerTestCases
    {
        public static List<int> GenerateIntegerValues(GroupInteger groupInteger)
        {
            if (groupInteger.OrderSuccess)
                return OrderSuccess(groupInteger, 
                    DelegateGroups(groupInteger));
            
            return DelegateGroups(groupInteger);
        }

        private static List<int> OrderSuccess(GroupInteger groupInteger, List<int> ints)
        {
            if (groupInteger.Order.Ascending)
                return ints.OrderBy(x => x).ToList();
            
            if (groupInteger.Order.Descending)
                return ints.OrderByDescending(x => x).ToList();
            
            throw new Exception("Invalid order");

        }

        private static List<int> DelegateGroups(GroupInteger groupInteger)
        {
            if (groupInteger.IntegerRangeSuccess)
                return IntegerRangeSuccess(groupInteger);
            
            if (groupInteger.IntegerOperatorSuccess)
                return IntegerOperatorSuccess(groupInteger);

            throw new Exception("Invalid group)");
        }

        private static List<int> IntegerOperatorSuccess(GroupInteger groupInteger)
        {
            if (groupInteger.IntegerComparisonOperator.IsEquals)
                return Enumerable.Repeat(groupInteger.IntegerValue, groupInteger.QuantityOfTestCases).ToList();

            if (groupInteger.IncrementSuccess)
                return HasOperatorWithIncrement(groupInteger);

            return HasOperator(groupInteger);
        }

        private static List<int> IntegerRangeSuccess(GroupInteger groupInteger)
        {
            if (groupInteger.IncrementSuccess)
                return HasIncrementAndRange(groupInteger);

            return HasRange(groupInteger);
        }

        private static List<int> HasOperatorWithIncrement(GroupInteger groupInteger)
        {
           int endingValue = groupInteger.IntegerComparisonOperator.IsGreaterThan
            ? groupInteger.IntegerValue
            : groupInteger.IntegerValue - 1;

            return GenerateIntegersWithIncrement(groupInteger);
            
        }
        private static List<int> HasOperator(GroupInteger groupInteger)
        {
            List<int> ints = new List<int>();

            if (groupInteger.IntegerComparisonOperator.IsGreaterThan)
                return Enumerable.Range(0, groupInteger.QuantityOfTestCases)
                     .Select(_ => new Random().Next(groupInteger.IntegerValue, int.MaxValue)).ToList();

            if (groupInteger.IntegerComparisonOperator.IsLessThan)
                return Enumerable.Range(0, groupInteger.QuantityOfTestCases)
                     .Select(_ => new Random().Next(int.MinValue, groupInteger.IntegerValue)).ToList();                
            
            throw new Exception("Invalid operator");
            
        }
        private static List<int> GenerateIntegersWithIncrement(GroupInteger groupInteger)
        {
            Func<int, int> operation = GenerateIncrementOperation(groupInteger);

            List<int> ints = new List<int>();

            int currentValue = groupInteger.IncrementValue;

            while (ints.Count < groupInteger.QuantityOfTestCases)
            {
                currentValue = operation(currentValue);
                ints.Add(currentValue);
            }
            return ints;
        }

        private static List<int> HasIncrementAndRange(GroupInteger groupInteger)
        {
            List<int> ints = new List<int>();
            Func<int, int> operation = GenerateIncrementOperation(groupInteger);
            for 
            (   
                int i = groupInteger.IntegerRangeFirstValue;

                (
                    groupInteger.IncrementOperator.IsMinus || groupInteger.IncrementOperator.IsDivide 
                    ? i > groupInteger.IntegerRangeSecondValue
                    : i < groupInteger.IntegerRangeSecondValue
                )

                && ints.Count < groupInteger.QuantityOfTestCases;
                
                i = operation(i)
            )
            {
                ints.Add(i);
            }
            return ints;
        }

        private static Func<int, int> GenerateIncrementOperation(GroupInteger groupInteger)
        {
            return groupInteger.IncrementOperator.IsPlus ? (Func<int, int>)(x => x + groupInteger.IncrementValue)
                : groupInteger.IncrementOperator.IsMinus ? (x => x - groupInteger.IncrementValue)
                : groupInteger.IncrementOperator.IsMultiply ? (x => x * groupInteger.IncrementValue)
                : groupInteger.IncrementOperator.IsDivide ? (x => x / groupInteger.IncrementValue)
                : throw new ArgumentException("Invalid increment operator");
        }

        private static List<int> HasRange(GroupInteger groupInteger)
        {
            List<int> ints = new List<int>();
            return Enumerable.Range(0, groupInteger.QuantityOfTestCases)
                 .Select(_ => new Random().Next(groupInteger.IntegerRangeFirstValue, groupInteger.IntegerRangeSecondValue)).ToList();
        }

        
    }
}
