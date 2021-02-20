using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebitelTest2.Models;

namespace WebitelTest2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductController : ControllerBase
    {
        IRepository<OrderProduct> OrderProductRepository;
        public OrderProductController(IRepository<OrderProduct> orderproductrepository)
        {
            OrderProductRepository = orderproductrepository;
        }
        [HttpGet()]
        public IEnumerable<OrderProduct> GetAll()
        {
            return OrderProductRepository.GetAll();
        }
       
        [HttpGet("{id}", Name = "OrderProductId")]
        public IActionResult Get(int Id)
        {
            OrderProduct orderprod = OrderProductRepository.Get(Id);
            if (orderprod == null)
            {
                return NotFound();
            }

            return new ObjectResult(orderprod);
        }
        [HttpPost]
        public IActionResult Create([FromBody] OrderProduct orderprod)
        {
            
            if (orderprod == null)
            {
                return BadRequest();
            }
            OrderProductRepository.Create(orderprod);
            return CreatedAtRoute("OrderProductId", new { id = orderprod.Id }, orderprod);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            var deletedOrdProd = OrderProductRepository.Delete(Id);

            if (deletedOrdProd == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedOrdProd);
        }
    }
}
