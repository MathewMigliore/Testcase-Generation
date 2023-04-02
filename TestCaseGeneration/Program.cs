namespace TestCaseGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var generator = new CreateTestCases(); 
            //var testCases = generator.Generate("string{s:10_c:[(){}[]]_t:5}");
            //testCases = generator.Generate("int{val:-10..-20}");
            string testCase1 = "int{val:>5}";
            string testCase2 = "int{val:-10..20 inc:+5 amt:5}";
            string testCase3 = "int{1d:=10 val:2..10 inc:*10 order:asc}";
            string testCase4 = "int{1d:5..10 val:5..15 order:asc}";
            string testCase5 = "int{1d:>5 val:-10..10 order:desc}";
            string testCase6 = "int{2d:=3 1d:=2 val:<-100}";
            string testCase7 = "int{2d_nbyn:=5 val:10..20 order:asc}";
            string testCase8 = "int{2d:=3 1d:=2 val:1..100 order:desc}";
            string testCase9 = "int{2d_nbyn:=5 val:-5..-3 order:asc}";
            string testCase10 = "int{1d:>3 val:=10}";

            var generatedTestCase1 = generator.Generate(testCase1);
            Console.WriteLine(generatedTestCase1);
            var generatedTestCase2 = generator.Generate(testCase2);
            Console.WriteLine(generatedTestCase2);
            var generatedTestCase3 = generator.Generate(testCase3);
            Console.WriteLine(generatedTestCase3);
            // var generatedTestCase4 = generator.Generate(testCase4);
            // var generatedTestCase5 = generator.Generate(testCase5);
            // var generatedTestCase6 = generator.Generate(testCase6);
            // var generatedTestCase7 = generator.Generate(testCase7);
            // var generatedTestCase8 = generator.Generate(testCase8);
            // var generatedTestCase9 = generator.Generate(testCase9);
            // var generatedTestCase10 = generator.Generate(testCase10);

            // foreach (var testCase in testCases)
            // {
            //     Console.WriteLine(generator.TestCaseToString(testCase));
            // }
            
            

        }
    }
}
