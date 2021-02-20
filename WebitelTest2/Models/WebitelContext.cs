using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebitelTest2.Models
{
    public class WebitelContext : DbContext
    {
        public WebitelContext(DbContextOptions<WebitelContext> options) : base(options)
        { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
      
    }
}
    

   