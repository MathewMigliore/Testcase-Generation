namespace TestCaseGenerator
{
    /// <summary>
    /// This section outlines the constants used for the regexes of test cases.
    /// The test case outlines are in the form of int{2d: ... 1d: ... val: ... }.
    /// </summary>
    public static class RegexConstants
    {
        /// <summary>
        /// This section is outlining the constants used for the regexes of matrix test cases.
        /// These test case outlines are in the form of int{2d: ... 1d: ... val: ... }.
        /// 2d: signifying the outer dimension of a 2d array.
        /// 1d: signifying the inner dimension of a 2d array.
        /// val: signifying the values inside the array.
        /// </summary>
        public const string GROUP_MATRIX = "group_matrix";
        public const string GROUP_NBYN = "group_nbyn";
        public const string GROUP_NBYN_OPERATOR = "group_nbyn_operator";
        public const string NBYN_DIM_COMPARISON_OPERATOR = "nbyn_dim_comparison_operator";
        public const string NBYN_DIM_VALUE = "nbyn_dim_value";
        public const string GROUP_NBYN_RANGE = "group_nbyn_range";
        public const string NBYN_DIM_RANGE_FIRST_VALUE = "nbyn_dim_range_first_value";
        public const string NBYN_DIM_RANGE_SECOND_VALUE = "nbyn_dim_range_second_value";
        public const string GROUP_NBYM_RANGE = "group_nbym_range";
        public const string NBYM_DIM_RANGE_FIRST_VALUE = "nbym_dim_range_first_value";
        public const string NBYM_DIM_RANGE_SECOND_VALUE = "nbym_dim_range_second_value";
        public const string GROUP_NBYM_OPERATOR = "group_nbym_operator";
        public const string NBYM_DIM_COMPARISON_OPERATOR = "nbym_dim_comparison_operator";
        public const string NBYM_DIM_VALUE = "nbym_dim_value";

        /// <summary>
        /// This section is outlining the constants used for the regexes of array test cases.
        /// These test case outlines are in the form of int{1d: ... val: ... }, 1d signifying a one-dimensional array.
        /// 1d: signifying the dimension of the array.
        /// val: signifying the values inside the array.
        /// </summary>
        public const string GROUP_ARRAY = "group_array";
        public const string GROUP_ARRAY_OPERATOR = "group_array_operator";
        public const string ARRAY_DIM_COMPARISON_OPERATOR = "array_dim_comparison_operator";
        public const string ARRAY_DIM_VALUE = "array_dim_value";
        public const string GROUP_ARRAY_RANGE = "group_array_range";
        public const string ARRAY_DIM_RANGE_FIRST_VALUE = "array_dim_range_first_value";
        public const string ARRAY_DIM_RANGE_SECOND_VALUE = "array_dim_range_second_value";

        /// <summary>
        /// This section is outlining the constants used for the regexes of integer test cases.
        /// These test case outlines are in the form of int{ val: ... }.
        /// val: signifying the values inside the test case.
        /// </summary>
        public const string GROUP_INTEGER = "group_integer";
        public const string GROUP_INTEGER_OPERATOR = "group_integer_operator";
        public const string INTEGER_COMPARISON_OPERATOR = "integer_comparison_operator";
        public const string INTEGER_VALUE = "integer_value";
        public const string GROUP_INTEGER_RANGE = "group_integer_range";
        public const string INTEGER_RANGE_FIRST_VALUE = "integer_range_first_value";
        public const string INTEGER_RANGE_SECOND_VALUE = "integer_range_second_value";

        // Additional constants for increments, order, and quantity of test cases.
        public const string GROUP_INCREMENT = "group_increment";
        public const string INCREMENT_OPERATOR = "increment_operator";
        public const string INCREMENT_VALUE = "increment_value";
        public const string ORDER = "order";
        public const string QUANTITY_OF_TEST_CASES = "quantity_of_test_cases";
    }
}
