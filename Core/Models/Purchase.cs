namespace Core.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CoffeeId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
