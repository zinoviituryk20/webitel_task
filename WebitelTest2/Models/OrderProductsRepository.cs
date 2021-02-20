
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace WebitelTest2.Models
{
    public class OrderProductsRepository : IRepository<OrderProduct>
    {
        private WebitelContext db;
        public OrderProductsRepository(WebitelContext context)
        {
            this.db = context;
        }
        public void Create(OrderProduct item)
        {
            //Update parametrs Amount in Product 
              Order order = db.Orders.Find(item.OrderId);

            /* var products = (from product in db.Products.Include(p => p.Id)
                          where product.Id == item.ProductId
                          select product).ToList(); */
            var product = db.Products.Find(item.ProductId);
            
             if (product != null &&  order != null)
              {
                  
                    order.Amount += product.Price;
                db.Orders.Update(order);
                db.SaveChanges();
                db.OrderProducts.Add(item);
                db.SaveChanges();


            }
            
        }

        public OrderProduct Delete(int id)
        {
           OrderProduct orderproduct= Get(id);
            if(orderproduct!=null)
            {
                db.OrderProducts.Remove(orderproduct);
                db.SaveChanges();
            }
            return orderproduct;
        }

        public OrderProduct Get(int id)
        {
            return db.OrderProducts.Find(id);
        }

        public IEnumerable<OrderProduct> GetAll()
        {
            return db.OrderProducts;
        }
    }
}
