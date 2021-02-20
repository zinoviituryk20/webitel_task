
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebitelTest2.Models
{
    public class Order
    {

        public Order() => OrderProducts = new HashSet<OrderProduct>();

        public int Id { get; set; }
        [StringLength(50)]
        public string Number { get; set; }
        public decimal Amount { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
