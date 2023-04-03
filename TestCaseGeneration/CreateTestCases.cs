
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
        /// Takes a string input and generates test cases according to the specified format through the use of Regex.
        /// Supports generating test cases for integers and n by n arrays of integers.
        ///
        /// The input string uses a custom syntax to define the properties of the generated test cases:
        ///
        /// For integers:
        ///
        /// - There are two possible input methods:
        ///     The range of integer values. Example: 1..10
        ///     Using an operator and an integer. Example: >10, <10, =10
        /// 
        /// Let NUM..NUM be RANGE, where NUM..NUM is the correct syntax to define a range.
        /// Let {>, <, =} be COMPARISON_OPERATOR, where {>, <, =} is the set of values allowed in the corrext syntax.
        /// Let {+, -, *, /} be OPERATOR, where {+, -, *, /} is the set of values allowed in the correct syntax.
        /// 
        /// - val:(RANGE | COMPARISON_OPERATOR NUM)  - The number of test cases to generate. Example: val:>10, <10, =10, 1..10
        /// - inc:OPERATOR NUM - The increment by which the integers should increase. Example: inc:+2
        /// - order:ORDER - The order in which the integers should be generated. Can be one of the following:
        ///     - asc - Generate integers in ascending order.
        ///     - desc - Generate integers in descending order.
        /// - amt:NUM - The number of total test cases. Example: amt:10
        /// 
        /// If there is no amount specified, the default is 10.
        /// If there is no inc or order, it will generate random integers defined by the range or comparison specified.
        ///
        /// Defines the dimension of an array of integers:
        /// - 1d:(RANGE | COMPARISON_OPERATOR) NUM - The size of the array. Example: 1d:=10, 1d:>5, 1d:5..10
        ///
        /// Defines the dimensions of an n by m matrix of integers:
        /// - 2d:(RANGE | COMPARISON_OPERATOR) NUM 1d:(RANGE | COMPARISON_OPERATOR) NUM - The size of the matrix. Example: 2d:=3 1d:=1, 2d:>3 1d:10..20
        /// 
        /// 
        /// Defines the dimensions for an n by n matrices of integers:
        /// - 2d_nbyn:(RANGE | COMPARISON_OPERATOR) - The size of the n by n matrix. Example: 2d_nbyn:=2, 2d_nbyn:>2
        ///
        /// Input examples:
        ///
        /// For single integers:
        ///     "int{val:1..100 amt:5}" - Generates 5 test cases of integers in the range 1 to 100.
        ///     "int{val:>20 inc:-2 amt:5}" - Generates 5 test cases of integers greater than 20, decreasing by 2.
        ///
        /// For arrays of integers:
        ///     "int{1d:=10 val:2..10 inc:*10 order:desc}" - Generates an array of size 10 with integers in the range 2 to 10, increasing by a factor of 10, then sorted decending.
        ///
        /// For n by m matrix of integers:
        ///     "int{2d:=3 1d:=2 val:<-100}" - Generates a 3x2 matrix of integers with values less than -100.
        /// 
        /// For n by n matrix of integers:
        ///     "int{2d_nbyn:=5 val:10..20 order:asc}" - Generates a 5x5 matrix of integers in the range 10 to 20, the values being in ascending order.
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
                throw new ArgumentException("Invalid input format.");
            

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
            
            throw new ArgumentException("Invalid input format.");
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
