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
            return await _context.ActionRecords.ToListAsync();
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
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                var exceptionEntry = e.Entries.Single();
                var clientValues = (ActionRecord)exceptionEntry.Entity;
                var databaseEntry = exceptionEntry.GetDatabaseValues();
                if (databaseEntry == null)
                {
                    ModelState.AddModelError(string.Empty,
                        "Unable to save changes. The department was deleted by another user.");
                }
                else
                {
                    var databaseValues = (ActionRecord)databaseEntry.ToObject();

                    ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                            + "was modified by another user after you got the original value. The "
                            + "edit operation was canceled and the current values in the database "
                            + "have been displayed. If you still want to edit this record, click "
                            + "the Save button again. Otherwise click the Back to List hyperlink.");
                    actionRecord.RowVersion = (byte[])databaseValues.RowVersion;
                    ModelState.Remove("RowVersion");
                }
            }
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
        public async Task<IActionResult> Delete(long id)
        {
            try
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
            catch (DbUpdateConcurrencyException e)
            {
                return NotFound();
            }
        }
    }
}
