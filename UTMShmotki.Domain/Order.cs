namespace UTMShmotki.Domain
{
    public class Order : Entity
    {
        public decimal TotalPrice { get; set; } = 0;
        public DateTime OrderMadeTime { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public decimal CalculateTotalPrice()
        {
            return Products.Select(p => p.Price).Sum();
        }
    }
}