using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Seminar11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductDbContext _context;

        public ProductsController(ProductDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products;
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var existing = _context.Products.FirstOrDefault(product => product.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            return Ok(existing);
        }





        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            var existing = _context.Products.AsNoTracking().FirstOrDefault(f => f.Id == id);
            if (existing == null)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok(product);
            }
            product.Id = id;
            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok(product);
        }


        // POST: api/Products
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            //if (!ModelState.IsValid)
            //{

            //}
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _context.Products.FirstOrDefault(flower => flower.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            _context.Products.Remove(existing);
            _context.SaveChanges();
            return Ok();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}