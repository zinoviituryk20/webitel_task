using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebitelTest2.Models
{
    public class OrderRepository : IRepository<Order>
    {
        private WebitelContext db;
        public OrderRepository(WebitelContext context)
        {
            this.db = context;
        }
        public void Create(Order item)
        {
         
            db.Orders.Add(item);
            db.SaveChanges();
        }

        public Order Delete(int id)
        {
            Order order = Get(id);
            if(order!=null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }
            return order;
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders;
        }
    }
}
