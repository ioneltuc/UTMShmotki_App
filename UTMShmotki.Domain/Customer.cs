namespace UTMShmotki.Domain
{
    public class Customer : Person
    {
        public DateTime JoinDate { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual Address Address { get; set; }
    }
}