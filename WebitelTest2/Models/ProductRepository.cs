using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebitelTest2.Models
{
    public class ProductRepository : IRepository<Product>
    {
        private WebitelContext db;
        public ProductRepository(WebitelContext context)
        {
            this.db = context;
         }
        public void Create(Product item)
        {
            db.Products.Add(item);
            db.SaveChanges();
        }

        public Product Delete(int id)
        {
            Product product = Get(id);
            if(product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
            return product;
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products;
        }
    }
}
