using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DigiwayModel;
using Microsoft.EntityFrameworkCore;

namespace DigiwayWebapi.Controllers
{
    [Route("api/[controller]")]
    public class CompaniesController : Controller
    {
        private DigiwayContext _context;

        public CompaniesController(DigiwayContext context)
        {
            this._context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Company>> Get()
        {
            return await _context.Companies.Include(u => u.Users).ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var existingCompany = await _context.Companies.Include(u => u.Users)
                                                        .Where(p => p.CompanyId == id)
                                                        .FirstOrDefaultAsync();
            if (existingCompany == null)
            {
                return NotFound();
            }
            return new ObjectResult(existingCompany);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Company company)
        {
            if (!ModelState.IsValid || company == null)
            {
                return BadRequest();
            }
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("DigiwayWebapi", new { id = company.CompanyId }, company);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody]Company company)
        {
            if (!ModelState.IsValid || company == null)
            {
                return BadRequest(ModelState);
            }
            var existingCompany = await _context.Companies.FindAsync(company.CompanyId);
            if (existingCompany == null)
            {
                return NotFound();
            }
            existingCompany.Name = company.Name;
            await _context.SaveChangesAsync();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingCompany = await _context.Companies.FindAsync(id);
            if (existingCompany == null)
            {
                return NotFound();
            }
            _context.Companies.Remove(existingCompany);
            await _context.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}
