namespace UTMShmotki.Domain
{
    public class Address : Entity
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int? ApartmentNumber { get; set; }
        public int? PostalCode { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}