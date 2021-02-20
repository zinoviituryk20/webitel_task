
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebitelTest2.Models
{
    public class Product
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
