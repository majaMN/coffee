namespace Core.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public decimal CashValuePerPoint { get; set; }
    }
}
