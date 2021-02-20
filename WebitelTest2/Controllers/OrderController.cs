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
    public class OrderController : ControllerBase
    {
        IRepository<Order> OrderRepository;
        public OrderController(IRepository<Order> orderrepository)
        {
            OrderRepository = orderrepository;
        }
        [HttpGet()]
        public IEnumerable<Order> GetAll()
        {
            return OrderRepository.GetAll();
        }
       
        [HttpGet("{id}", Name = "GetItemId")]
        public IActionResult Get(int Id)
        {
            Order order = OrderRepository.Get(Id);
            if (order == null)
            {
                return NotFound();
            }

            return new ObjectResult(order)  ;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            OrderRepository.Create(order);
            return CreatedAtRoute("GetItemId", new { id = order.Id }, order);
        }
       
        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            var deletedTodoItem = OrderRepository.Delete(Id);

            if (deletedTodoItem == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedTodoItem);
        }
    }
}
