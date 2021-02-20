using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebitelTest2.Models
{
    public class UOWWebitelContext :IDisposable
    {

        private WebitelContext db;
        private OrderRepository orderRepository;
        private ProductRepository productRepository;
        private OrderProductsRepository orderProductRepository;
        public OrderRepository Orders
        {
            get { if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            
            }
        }
        public ProductRepository Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }
        public OrderProductsRepository OrdersProduct
        {
            get
            {
                if (orderProductRepository == null)
                    orderProductRepository = new OrderProductsRepository(db);
                return orderProductRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
