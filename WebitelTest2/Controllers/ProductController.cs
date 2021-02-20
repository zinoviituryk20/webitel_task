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
    public class ProductController : ControllerBase
    {
        IRepository<Product> ProductRepository;
         public ProductController(IRepository<Product> productrepository)
        {
            ProductRepository = productrepository;
        }
        [HttpGet()]
        public IEnumerable<Product> GetAll()
        {
            return ProductRepository.GetAll();
        }
       
        [HttpGet("{id}", Name = "GetProductId")]
        public IActionResult Get(int Id)
        {
            Product prod = ProductRepository.Get(Id);
            if (prod == null)
            {
                return NotFound();
            }

            return new ObjectResult(prod);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            ProductRepository.Create(product);
            return CreatedAtRoute("GetProductId", new { id = product.Id }, product);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            var deletedprod = ProductRepository.Delete(Id);

            if (deletedprod == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedprod);
        }
    }
}
