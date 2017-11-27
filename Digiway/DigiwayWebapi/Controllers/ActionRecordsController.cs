using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigiwayWebapi.Models;

namespace DigiwayWebapi.Controllers
{
    [Route("api/[controller]")]
    public class ActionRecordsController : Controller
    {
        private DigiwayContext _context;

        public ActionRecordsController(DigiwayContext context)
        {
            this._context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<ActionRecord>> Get()
        {
            return await _context.ActionRecords.Include(u => u.User)
                                                .Include(pr => pr.PurchaseRecords)
                                                .Include(tr => tr.TransferRecords)
                                                .ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var existingActionRecord = await _context.ActionRecords.FindAsync(id);
            if (existingActionRecord == null)
            {
                return NotFound();
            }
            return new ObjectResult(existingActionRecord);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ActionRecord actionRecord)
        {
            if (!ModelState.IsValid || actionRecord == null)
            {
                return BadRequest();
            }
            await _context.ActionRecords.AddAsync(actionRecord);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("DigiwayWebapi", new { id = actionRecord.ActionRecordId }, actionRecord);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody]ActionRecord actionRecord)
        {
            if (!ModelState.IsValid || actionRecord == null)
            {
                return BadRequest(ModelState);
            }
            var existingActionRecord = await _context.ActionRecords.FindAsync(actionRecord.ActionRecordId);
            if (existingActionRecord == null)
            {
                return NotFound();
            }
            existingActionRecord.Description = actionRecord.Description;
            existingActionRecord.RecordDate = actionRecord.RecordDate;
            existingActionRecord.User = actionRecord.User;
            await _context.SaveChangesAsync();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingActionRecord = await _context.ActionRecords.FindAsync(id);
            if (existingActionRecord == null)
            {
                return NotFound();
            }
            _context.ActionRecords.Remove(existingActionRecord);
            await _context.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}
