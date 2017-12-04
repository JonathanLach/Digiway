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
    public class UsersController : Controller
    {
        private DigiwayContext _context;

        public UsersController(DigiwayContext context)
        {
            this._context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _context.Users.Include(uc => uc.Companies).ThenInclude(c => c.Company)
                        .ToListAsync();
        }

        [HttpGet("username/{userName}")]
        public async Task<IActionResult> GetByUsername(string userName)
        {
            var existingUser = await _context.Users.Where(u=> u.Login == userName).FirstOrDefaultAsync();
            if (existingUser == null)
            {
                return NotFound();
            }
            return new ObjectResult(existingUser);
        }

        // GET api/values/5
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var existingUser = await _context.Users.Where(u=> u.UserId == id).FirstOrDefaultAsync();
            if (existingUser == null)
            {
                return NotFound();
            }
            return new ObjectResult(existingUser);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]User u)
        {
            if (!ModelState.IsValid || u == null)
            {
                return BadRequest();
            }
            await _context.Users.AddAsync(u);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("DigiwayWebapi", new { id = u.UserId }, u);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody]User u)
        {

            if (!ModelState.IsValid || u == null)
            {
                return BadRequest(ModelState);
            }
            var existingUser = await _context.Users.FindAsync(u.UserId);
            if (existingUser == null)
            {
                return NotFound();
            }
            existingUser.Address = u.Address;
            existingUser.City = u.City;
            existingUser.Companies = u.Companies;
            existingUser.AccessRights = u.AccessRights;
            existingUser.ActionRecords = u.ActionRecords;
            existingUser.FirstName = u.FirstName;
            existingUser.Hashcode = u.Hashcode;
            existingUser.IBANAccount = u.IBANAccount;
            existingUser.LastName = u.LastName;
            existingUser.Login = u.Login;
            existingUser.Money = u.Money;
            existingUser.Password = u.Password;
            existingUser.TelNumber = u.TelNumber;
            existingUser.ZIP = u.ZIP;
            await _context.SaveChangesAsync();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            _context.Users.Remove(existingUser);
            await _context.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}
