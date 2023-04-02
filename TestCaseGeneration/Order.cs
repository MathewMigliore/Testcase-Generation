namespace TestCaseGenerator
{
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
}

