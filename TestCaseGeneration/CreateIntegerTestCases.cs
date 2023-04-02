namespace TestCaseGenerator
{
    public static class CreateIntegerTestCases
    {
        public static string GenerateIntegerValues(GroupInteger groupInteger)
        {
            List<int> ints = new List<int>();
            if (groupInteger.IntegerRangeSuccess)
            {
                ints = HasRange(groupInteger);
            }
            else if (groupInteger.IntegerOperatorSuccess)
            {
                ints = HasSign(groupInteger);
            }

            if (groupInteger.OrderSuccess)
            {
                if (groupInteger.Order.Ascending)
                {
                    ints.Sort();
                }
                else if (groupInteger.Order.Descending)
                {
                    ints.Sort();
                    ints.Reverse();
                }
            }
            
            return IntListToString(ints);
        }
        private static string IntListToString(List<int> ints)
        {
            string str = "";
            foreach (int i in ints)
            {
                str += i + "\n";
            }
            return str;
        }
        private static List<int> HasSign(GroupInteger groupInteger)
        {
            List<int> ints = new List<int>();

            if (groupInteger.IntegerComparisonOperator.IsEquals)
            {
                return Enumerable.Repeat(groupInteger.IntegerValue, groupInteger.QuantityOfTestCases).ToList();
            }

            if (groupInteger.IntegerComparisonOperator.IsGreaterThan)
            {
                if (groupInteger.IncrementSuccess)
                {
                    int endingValue = CalculateWithEndOfIncrement(groupInteger.IncrementOperator, groupInteger.IncrementValue, groupInteger.QuantityOfTestCases);

                    return HasIncrement(groupInteger.IncrementOperator, groupInteger.IncrementValue, groupInteger.IntegerValue, endingValue, groupInteger.QuantityOfTestCases);

                }
                else
                {
                    return Enumerable.Range(0, groupInteger.QuantityOfTestCases)
                     .Select(_ => new Random().Next(groupInteger.IntegerValue, int.MaxValue)).ToList();
                }
            }
            else if (groupInteger.IntegerComparisonOperator.IsLessThan)
            {
                if (groupInteger.IncrementSuccess)
                {
                    int endingValue = CalculateWithEndOfIncrement(groupInteger.IncrementOperator, groupInteger.IncrementValue, groupInteger.QuantityOfTestCases);

                    return HasIncrement(groupInteger.IncrementOperator, groupInteger.IncrementValue, groupInteger.IntegerValue, endingValue, groupInteger.QuantityOfTestCases);
                }
                else
                {
                    return Enumerable.Range(0, groupInteger.QuantityOfTestCases)
                     .Select(_ => new Random().Next(int.MinValue, groupInteger.IntegerValue)).ToList();
                }
                
            }
            else
            {
                throw new Exception("Invalid sign (how did you even get here?))");
            }
        }

        private static int CalculateWithEndOfIncrement(IncrementOperator incrementOperator, int incrementValue, int quantityOfTestCases)
        {
            if (incrementOperator.IsPlus)
                return incrementValue * quantityOfTestCases;
            else if (incrementOperator.IsMinus)
                return -(incrementValue * quantityOfTestCases);
            else if (incrementOperator.IsMultiply)
                return incrementValue ^ quantityOfTestCases;
            else if (incrementOperator.IsDivide)
                return 1 / (incrementValue ^ quantityOfTestCases);
            else
                throw new Exception("Invalid increment sign");
        }
        
        private static List<int> HasIncrement(IncrementOperator incrementOperator, int incrementValue, int start, int end, int quantityOfTestCases)
        {
            List<int> ints = new List<int>();            
            if (incrementOperator.IsPlus)
            {
                for (int i = start; i < end && ints.Count < quantityOfTestCases; i += incrementValue) { ints.Add(i); }
            }
            else if (incrementOperator.IsMinus)
            {
                for (int i = start; i > end && ints.Count < quantityOfTestCases; i -= incrementValue)  { ints.Add(i); }
            }
            else if (incrementOperator.IsMultiply)
            {
                for (int i = start; i < end && ints.Count < quantityOfTestCases; i *= incrementValue)  { ints.Add(i); }
            }
            else if (incrementOperator.IsDivide)
            {
                for (int i = start; i < end && ints.Count < quantityOfTestCases; i /= incrementValue)  { ints.Add(i); }
            }
            return ints;
        }
        private static List<int> HasRange(GroupInteger groupInteger)
        {
            List<int> ints = new List<int>();

            if (groupInteger.IncrementSuccess)
            {
                return HasIncrement(groupInteger.IncrementOperator, groupInteger.IncrementValue, groupInteger.IntegerRangeFirstValue, groupInteger.IntegerRangeSecondValue, groupInteger.QuantityOfTestCases);
            }
            else
            {
                return Enumerable.Range(0, groupInteger.QuantityOfTestCases)
                 .Select(_ => new Random().Next(groupInteger.IntegerRangeFirstValue, groupInteger.IntegerRangeSecondValue)).ToList();
            }
        }

        
    }
}
