using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTMShmotki.Domain
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } = 0;
        public virtual ICollection<Order> Orders { get; set; }
    }
}