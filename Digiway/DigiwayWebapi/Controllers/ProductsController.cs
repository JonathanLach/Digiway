using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DigiwayWebapi.Models;
using Microsoft.EntityFrameworkCore;

namespace DigiwayWebapi.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private DigiwayContext _context;

        public ProductsController(DigiwayContext context)
        {
            this._context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _context.Products.Include(pc => pc.ProductCategory).ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var existingProduct = await _context.Products.Include(pc => pc.ProductCategory)
                                                    .Where(p => p.ProductId == id)
                                                    .FirstOrDefaultAsync();
            if (existingProduct == null)
            {
                return NotFound();
            }
            return new ObjectResult(existingProduct);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Product product)
        {
            if (!ModelState.IsValid || product == null)
            {
                return BadRequest();
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("DigiwayWebapi", new { id = product.ProductId }, product);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody]Product product)
        {
            if (!ModelState.IsValid || product == null)
            {
                return BadRequest(ModelState);
            }
            var existingProduct = await _context.Products.FindAsync(product.ProductId);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.Name = product.Name;
            existingProduct.IsCustom = product.IsCustom;
            existingProduct.ProductId = product.ProductId;
            existingProduct.ProductCategory = product.ProductCategory;
            existingProduct.PurchaseRecords = existingProduct.PurchaseRecords;
            await _context.SaveChangesAsync();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            _context.Products.Remove(existingProduct);
            await _context.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}
