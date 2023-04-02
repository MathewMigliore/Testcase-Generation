
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using static TestCaseGenerator.RegexConstants;
namespace TestCaseGenerator
{

    public class CreateTestCases
    {
        /// <summary>
        /// Takes a string input and generates test cases according to the specified format.
        /// Supports generating test cases for different data types, such as integers, floating-point numbers, strings, and n by n arrays of integers.
        ///
        /// The input string uses a custom syntax to define the properties of the generated test cases:
        ///
        /// For integers:

        /// - i:RANGE - The range of integer values. Example: i:1..10
        /// - t:NUM - The number of test cases to generate. Example: t:5
        /// - o:ORDER - The order in which the integers should be generated. Can be one of the following:
        ///     - o:asc - Generate integers in ascending order.
        ///     - o:desc - Generate integers in descending order.
        /// - inc:INCREMENT - The increment by which the integers should increase. Example: inc:2
        /// - exp:BASE - The base for exponential increments. Example: exp:2
        /// - func:FUNCTION - A mathematical function to generate integer values. Example: func:x^2
        ///
        ///
        /// For floating-point numbers:
        /// - f:RANGE - The range of floating-point values. Example: f:1.0..10.0
        /// - d:NUM - The number of decimal places. Example: d:2
        /// - t:NUM - The number of test cases to generate. Example: t:5
        ///
        /// For strings:
        /// - s:LENGTH - The length of the generated strings. Example: s:10
        /// - c:CHARSET - The character set used for the generated strings. Can be one of the following:
        ///     - c:words - A predefined set of words (e.g., apple, banana, orange).
        ///     - c:lowercase - Lowercase letters (a-z).
        ///     - c:uppercase - Uppercase letters (A-Z).
        ///     - c:nonletters - Non-letter characters (digits and symbols).
        ///     - c:all - All available characters (letters, digits, and symbols).
        ///     - c:[CUSTOM] - A custom set of characters defined by the user. Example: c:[abc123]
        /// - t:NUM - The number of test cases to generate. Example: t:5
        ///
        /// For n by n array of integers:
        /// - a:RANGE - The range of integer values. Example: a:1..10
        /// - n:SIZE - The size of the n by n array. Example: n:3
        /// - t:NUM - The number of test cases to generate. Example: t:2
        ///
        /// Input examples:
        ///
        /// For integers:
        /// 1. "int{i:1..100_t:5}" - Generates 5 test cases of integers in the range 1 to 100.
        /// ...
        /// 10. "int{i:50..100_t:8}" - Generates 8 test cases of integers in the range 50 to 100.
        ///
        /// For n by n array of integers:
        /// 1. "array{a:1..100_n:3_t:2}" - Generates 2 test cases of 3x3 arrays with integer values in the range 1 to 100.
        ///
        /// </summary>


        public string Generate(string input)
        {
            Console.WriteLine(input);
            if (input.StartsWith("int"))
            {

                return GenerateIntTestCases(input);
            }
            else if (input.StartsWith("float"))
            {
                return TestCaseToString(GenerateFloatTestCases(input));
            }
            else if (input.StartsWith("string"))
            {
                return TestCaseToString(GenerateStringTestCases(input));
            }
            else if (input.StartsWith("array"))
            {
                return TestCaseToString(GenerateArrayTestCases(input));
            }
            else
            {
                throw new ArgumentException("Invalid input format.");
            }
        }

        private string GenerateIntTestCases(string input)
        {
            
            // Parse and validate the input string
            var intRegex = new Regex(@"int\{(?:2d(?<group_matrix>(?<group_nbyn>(?:_nbyn:(?:(?<group_nbyn_operator>(?<nbyn_dim_comparison_operator><|>|=)(?<nbyn_dim_value>\d+))|(?<group_nbyn_range>(?<nbyn_dim_range_first_value>[+\-]?\d+)\.\.(?<nbyn_dim_range_second_value>[+\-]?\d+))))?)?|:(?:(?<group_nbym_operator>(?<nbym_dim_comparison_operator><|>|=)(?<nbym_dim_value>\d+))|(?<group_nbym_range>(?<nbym_dim_range_first_value>[+\-]?\d+)\.\.(?<nbym_dim_range_second_value>[+\-]?\d+))))? )?(?:1d:(?<group_array>(?<group_array_operator>(?<array_dim_comparison_operator><|>|=)(?<array_dim_value>\d+))|(?<group_array_range>(?<array_dim_range_fist_value>[+\-]?\d+)\.\.(?<array_dim_range_second_value>[+\-]?\d+)))? )?val:(?<group_integer>(?<group_integer_operator>(?<integer_comparison_operator>>|<|=)(?<integer_value>[+\-]?\d+))|(?<group_integer_range>(?<integer_range_first_value>[+\-]?\d+)\.\.(?<integer_range_second_value>[+\-]?\d+)))(?: inc:(?<group_increment>(?<increment_operator>[+\-\*\/])(?<increment_value>\d+)))?(?: order:(?<order>asc|desc))?(?: amt:(?<quantity_of_test_cases>\d+))?\}");
            var match = intRegex.Match(input);
            if (!match.Success)
            {
                throw new ArgumentException("Invalid input format.");
            }
            if (match.Groups[GROUP_MATRIX].Success)
            {
                // Generate 2D matrix based on the matched group values

                // ... (Implement logic to generate 2D matrix)

                // Add the generated integers to the list (flatten the 2D matrix)
                //generatedIntegers.AddRange(/* flattened 2D matrix */);
                throw new NotImplementedException();
            }

            if (match.Groups[GROUP_ARRAY].Success)
            {
                // Generate 1D array based on the matched group values
                
                
                // ... (Implement logic to generate 1D array)

                // Add the generated integers to the list
                //generatedIntegers.AddRange(/* generated 1D array */);
                throw new NotImplementedException();
            }

            if (match.Groups[GROUP_INTEGER].Success)          
                return IntListToString(CreateIntegerTestCases.GenerateIntegerValues(new GroupInteger(match)));



            throw new ArgumentException("Invalid input format.");
            
        }


        private List<object> GenerateFloatTestCases(string input)
        {
            // Parse and validate the input string
            var floatRegex = new Regex(@"float\{f:(?<range>[0-9.]+\.\.[0-9.]+)(?<sign>[-+]?)(?<exact>=?)_d:(?<decimal>\d+)_t:(?<count>\d+)(_o:(?<order>asc|desc))?(_inc:(?<increment>[0-9.]+))?(_exp:(?<exponent>[0-9.]+))?(_func:(?<function>[^_]+))?}");
            var match = floatRegex.Match(input);
            if (!match.Success)
            {
                throw new ArgumentException("Invalid float input format.");
            }

            var range = match.Groups["range"].Value.Split(new string[] { ".." }, StringSplitOptions.None).Select(double.Parse).ToArray();
            string sign = match.Groups["sign"].Value;
            string exact = match.Groups["exact"].Value;
            int decimalPlaces = int.Parse(match.Groups["decimal"].Value);
            int count = int.Parse(match.Groups["count"].Value);
            string order = match.Groups["order"].Value;
            string increment = match.Groups["increment"].Value;
            string exponent = match.Groups["exponent"].Value;
            string function = match.Groups["function"].Value;

            if (range.Length != 2 || range[0] > range[1])
            {
                throw new ArgumentException("Invalid range specified.");
            }

            // Generate the test cases
            var random = new Random();
            var testCases = new List<object>();
            double current = range[0];

            for (int i = 0; i < count; i++)
            {
                double value;

                if (!string.IsNullOrEmpty(exact))
                {
                    value = range[0];
                }
                else
                {
                    if (!string.IsNullOrEmpty(order))
                    {
                        if (order == "asc")
                        {
                            value = current;
                        }
                        else
                        {
                            value = range[1] - (current - range[0]);
                        }

                        if (!string.IsNullOrEmpty(increment))
                        {
                            double inc = double.Parse(increment);
                            current += inc;
                        }
                        else if (!string.IsNullOrEmpty(exponent))
                        {
                            double baseValue = double.Parse(exponent);
                            double exponentValue = Math.Pow(baseValue, i);
                            current = range[0] + exponentValue;
                        }
                        else if (!string.IsNullOrEmpty(function))
                        {
                            //value = EvaluateFunction(function, i);
                        }
                        else
                        {
                            value = random.NextDouble() * (range[1] - range[0]) + range[0];
                        }
                    }
                    else
                    {
                        value = random.NextDouble() * (range[1] - range[0]) + range[0];
                    }
                }

                if (sign == "-")
                {
                    value = -Math.Abs(value);
                }
                else if (sign == "+")
                {
                    value = Math.Abs(value);
                }

                double roundedValue = Math.Round(value, decimalPlaces);
                testCases.Add(roundedValue);
            }

            return testCases;
        }



        private List<object> GenerateStringTestCases(string input)
        {
            // Parse and validate the input string
            var stringRegex = new Regex(@"string\{s:(?<length>\d+)_c:(?<charset>\w+|words|\[.+])_t:(?<count>\d+)\}");
            var match = stringRegex.Match(input);
            if (!match.Success)
            {
                throw new ArgumentException("Invalid string input format.");
            }

            int length = int.Parse(match.Groups["length"].Value);
            string charset = match.Groups["charset"].Value;
            int count = int.Parse(match.Groups["count"].Value);

            // Define the character set
            string characters;
            if (charset == "words")
            {
                // TODO: Implement support for generating strings using a predefined set of words
                throw new NotImplementedException("Support for predefined word sets is not implemented.");
            }
            else if (charset == "lowercase")
            {
                characters = "abcdefghijklmnopqrstuvwxyz";
            }
            else if (charset == "uppercase")
            {
                characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }
            else if (charset == "nonletters")
            {
                characters = "0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
            }
            else if (charset == "all")
            {
                characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
            }
            else if (charset.StartsWith("[") && charset.EndsWith("]"))
            {
                characters = charset.Substring(1, charset.Length - 2);
            }
            else
            {
                throw new ArgumentException("Invalid charset specified.");
            }

            // Generate the test cases
            var random = new Random();
            var testCases = new List<object>();

            for (int i = 0; i < count; i++)
            {
                var stringBuilder = new StringBuilder(length);

                for (int j = 0; j < length; j++)
                {
                    int index = random.Next(characters.Length);
                    stringBuilder.Append(characters[index]);
                }

                testCases.Add(stringBuilder.ToString());
            }

            return testCases;
        }


        private List<object> GenerateArrayTestCases(string input)
        {
            // Parse and validate the input string
            var arrayRegex = new Regex(@"array\{a:(?<range>\d+\.\.\d+)_n:(?<size>\d+)_t:(?<count>\d+)\}");
            var match = arrayRegex.Match(input);
            if (!match.Success)
            {
                throw new ArgumentException("Invalid array input format.");
            }

            var range = match.Groups["range"].Value.Split(new string[] { ".." }, StringSplitOptions.None).Select(int.Parse).ToArray();
            int size = int.Parse(match.Groups["size"].Value);
            int count = int.Parse(match.Groups["count"].Value);

            if (range.Length != 2 || range[0] > range[1])
            {
                throw new ArgumentException("Invalid range specified.");
            }

            // Generate the test cases
            var random = new Random();
            var testCases = new List<object>();

            for (int i = 0; i < count; i++)
            {
                int[,] array = new int[size, size];

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        int value = random.Next(range[0], range[1] + 1);
                        array[row, col] = value;
                    }
                }

                testCases.Add(array);
            }

            return testCases;
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
        private string TestCaseToString(object testCase)
        {
            StringBuilder sb = new StringBuilder();
            Type testCaseType = testCase.GetType();
            if (testCaseType.IsGenericType && (testCaseType.GetGenericTypeDefinition() == typeof(List<>)))
            {
                testCase.GetType().GetMethod("ForEach").Invoke(testCase, new object[] { new Action<object>(x => sb.Append(x.ToString() + "\n")) });
            }
            
            if (testCaseType.IsArray)
            {
                Array array = (Array)testCase;
                sb.Append("[");
                for (int i = 0; i < array.Length; i++)
                {
                    object element = array.GetValue(i);
                    if (element.GetType().IsArray)
                    {
                        sb.Append(TestCaseToString(element));
                    }
                    else
                    {
                        sb.Append(element.ToString());
                        Console.WriteLine(element.ToString());
                    }

                    if (i < array.Length - 1)
                    {
                        sb.Append(", ");
                    }
                }
                sb.Append("]");
            }
            else
            {
                sb.Append(testCase.ToString());
            }
            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }
    }
}
