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
    public class PurchaseRecordsController : Controller
    {
        private DigiwayContext _context;

        public PurchaseRecordsController(DigiwayContext context)
        {
            this._context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<PurchaseRecord>> Get()
        {
            return await _context.PurchaseRecords.Include(p => p.Product)
                                                .Include(e => e.Event)
                                                .Include(ar => ar.ActionRecord)
                                                .ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var existingPurchaseRecord = await _context.PurchaseRecords.Include(p => p.Product)
                                                                        .Include(e => e.Event)
                                                                        .Include(ar => ar.ActionRecord)
                                                                        .FirstOrDefaultAsync();
            if (existingPurchaseRecord == null)
            {
                return NotFound();
            }
            return new ObjectResult(existingPurchaseRecord);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PurchaseRecord purchaseRecord)
        {
            if (!ModelState.IsValid || purchaseRecord == null)
            {
                return BadRequest();
            }
            await _context.PurchaseRecords.AddAsync(purchaseRecord);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("DigiwayWebapi", new { id = purchaseRecord.PurchaseRecordId }, purchaseRecord);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody]PurchaseRecord purchaseRecord)
        {
            if (!ModelState.IsValid || purchaseRecord == null)
            {
                return BadRequest(ModelState);
            }
            var existingPurchaseRecord = await _context.PurchaseRecords.FindAsync(purchaseRecord.PurchaseRecordId);
            if (existingPurchaseRecord == null)
            {
                return NotFound();
            }
            existingPurchaseRecord.Product = purchaseRecord.Product;
            existingPurchaseRecord.Event = purchaseRecord.Event;
            existingPurchaseRecord.Quantity = purchaseRecord.Quantity;
            existingPurchaseRecord.UnitPrice = purchaseRecord.UnitPrice;
            existingPurchaseRecord.ActionRecord = purchaseRecord.ActionRecord;
            await _context.SaveChangesAsync();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingPurchaseRecord = await _context.PurchaseRecords.FindAsync(id);
            if (existingPurchaseRecord == null)
            {
                return NotFound();
            }
            _context.PurchaseRecords.Remove(existingPurchaseRecord);
            await _context.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}
