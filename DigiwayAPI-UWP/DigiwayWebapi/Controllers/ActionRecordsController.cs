using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigiwayWebapi.Models;
using System.Net;

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
        [HttpGet("id/{id}", Name ="GetActionById")]
        public async Task<IActionResult> GetById(long id)
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
            return CreatedAtRoute("GetActionById", new { id = actionRecord.ActionRecordId }, actionRecord);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put(long id, [FromBody]ActionRecord actionRecord)
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
            var existingActionRecord = await _context.ActionRecords.FirstOrDefaultAsync(ar => ar.ActionRecordId == id);
            if (existingActionRecord == null)
            {
                return NotFound();
            }
            _context.ActionRecords.Remove(existingActionRecord);
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
