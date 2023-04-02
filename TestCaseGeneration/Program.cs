namespace TestCaseGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var generator = new CreateTestCases(); 

            // string[] groupIntegerTestCases = new string[]
            // {
            //     "int{val:>5}",
            //     "int{val:-10..20 inc:+5 amt:5}",
            //     "int{val:10..-20 inc:-5 amt:5}",
            //     "int{val:10..200000 inc:*2 amt:10}",
            //     "int{val:10..200000 inc:*2 order:desc amt:16}",
            //     "int{val:10..0 inc:/2 amt:10}",
            //     "int{val:10..0 inc:/2 order:asc amt:10}",
            //     "int{val:<100 inc:+3 amt:10}",
            //     "int{val:>20 inc:-2 amt:5}",
            //     "int{val:<-10 inc:+1 amt:3}",
            //     "int{val:>-30 inc:+4 amt:7}",
            //     "int{val:10..20 inc:+1 amt:5}",
            //     "int{val:-50..-20 inc:+5 amt:6}",
            //     "int{val:-100..100 inc:+10 amt:10}",
            //     "int{val:30..50 inc:+1 amt:8}",
            //     "int{val:300..1000 inc:*2 amt:5}",
            //     "int{val:100..0 inc:/2 amt:4}",
            //     "int{val:<50 inc:+3 order:desc amt:8}",
            //     "int{val:>60 inc:-4 order:asc amt:6}",
            //     "int{val:<-5 inc:+2 order:desc amt:7}",
            //     "int{val:>-25 inc:+5 order:asc amt:5}",
            //     "int{val:10..30 inc:+2 order:desc amt:4}",
            //     "int{val:-70..-30 inc:+7 order:asc amt:6}",
            //     "int{val:-200..200 inc:+20 order:desc amt:10}",
            //     "int{val:400..70 inc:-2 order:asc amt:6}",
            //     "int{val:400..1500 inc:*2 order:desc amt:6}",
            //     "int{val:1..200 inc:*2 order:asc amt:7}",
            //     "int{val:<150 inc:+6 amt:8}",
            //     "int{val:>70 inc:-3 amt:5}",
            //     "int{val:<-15 inc:+3 amt:4}",
            //     "int{val:>-45 inc:+6 amt:7}",
            //     "int{val:20..40 inc:+2 amt:5}",
            //     "int{val:-80..-40 inc:+4 amt:10}",
            //     "int{val:-300..300 inc:+30 amt:7}",
            //     "int{val:500..80 inc:/3 amt:6}",
            //     "int{val:500..2000 inc:*2 amt:6}",
            //     "int{val:1000..300 inc:/2 amt:5}",
            //     "int{val:<200 inc:+4 order:desc amt:10}",
            //     "int{val:>80 inc:-5 order:asc amt:5}",
            //     "int{val:<-20 inc:+5 order:desc amt:6}",
            //     "int{val:>-65 inc:+7 order:asc amt:4}",
            //     "int{val:30..60 inc:+3 order:desc amt:5}",
            //     "int{val:-90..-60 inc:+6 order:asc amt:7}",
            //     "int{val:-400..400 inc:+40 order:desc amt:8}",
            //     "int{val:600..90 inc:-4 order:asc amt:6}",
            //     "int{val:600..2500 inc:*2 order:desc amt:7}",
            //     "int{val:1000..400 inc:/2 order:asc amt:6}",
            //     "int{val:<250 inc:+5 amt:7}",
            //     "int{val:>90 inc:-6 amt:6}",
            //     "int{val:<-25 inc:+7 amt:5}",
            //     "int{val:>-85 inc:+8 amt:8}",
            //     "int{val:40..70 inc:+4 amt:6}",
            //     "int{val:-100..-70 inc:+5 amt:9}",
            // };

            // foreach (var testCase in groupIntegerTestCases)
            // {
            //     var generatedTestCase = generator.Generate(testCase);
            //     Console.WriteLine(generatedTestCase);
            // }

            string[] groupArrayTestCases = new string[]
            {
                    "int{1d:=10 val:2..10 inc:*10 order:asc}",
                    "int{1d:5..10 val:5..15 order:asc}",
                    "int{1d:>5 val:-10..10 order:desc}",
                    "int{1d:>3 val:=10}",
            };
            foreach (var testCase in groupArrayTestCases)
            {
                var generatedTestCase = generator.Generate(testCase);
                Console.WriteLine(generatedTestCase);
            }
            // string[] groupMatrixTestCases = new string[]
            // {
            //     "int{2d:=3 1d:=2 val:<-100}",
            //     "int{2d_nbyn:=5 val:10..20 order:asc}",
            //     "int{2d:=3 1d:=2 val:1..100 order:desc}",
            //     "int{2d_nbyn:=5 val:-5..-3 order:asc}"
            // };     
            // foreach (var testCase in groupMatrixTestCases)
            // {
            //     var generatedTestCase = generator.Generate(testCase);
            //     Console.WriteLine(generatedTestCase);
            // }    
                
            

        }
    }
}
