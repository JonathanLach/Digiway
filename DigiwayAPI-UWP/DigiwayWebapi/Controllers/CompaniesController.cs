using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DigiwayWebapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace DigiwayWebapi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CompaniesController : Controller
    {
        private DigiwayContext _context;

        public CompaniesController(DigiwayContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Company>> Get()
        {
            return await _context.Companies.Include(u => u.Users).ToListAsync();
        }

        [HttpGet("id/{id}", Name ="GetCompanyById")]
        public async Task<IActionResult> GetById(long id)
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
            return CreatedAtRoute("GetCompanyById", new { id = company.CompanyId }, company);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put(long id, [FromBody]Company company)
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
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return StatusCode((int)HttpStatusCode.Conflict);
            }
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("id/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var existingCompany = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == id);
            if (existingCompany == null)
            {
                return NotFound();
            }
            _context.Companies.Remove(existingCompany);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return StatusCode((int)HttpStatusCode.Conflict);
            }
            return new NoContentResult();
        }
    }
}
