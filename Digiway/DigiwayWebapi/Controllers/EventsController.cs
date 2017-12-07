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
    public class EventsController : Controller
    {
        private DigiwayContext _context;

        public EventsController(DigiwayContext context)
        {
            this._context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Event>> Get()
        {
            return await _context.Events
                    .Include(ec => ec.EventCategory)
                    .Include(poi => poi.PointsOfInterest)
                    .Include(c => c.Company)
                    .ToListAsync();
        }

        // GET api/values/5
        [HttpGet("id/{id}", Name = "GetEventById")]
        public async Task<IActionResult> GetById(long id)
        {
            var existingEvent = await _context.Events
                                .Include(ec => ec.EventCategory)
                                .Include(poi => poi.PointsOfInterest)
                                .Include(c => c.Company)
                                .Where(e => e.EventId == id)
                                .FirstOrDefaultAsync();
            if (existingEvent == null)
            {
                return NotFound();
            }
            return new ObjectResult(existingEvent);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Event e)
        {
            if(!ModelState.IsValid || e == null)
            {
                return BadRequest();
            }
            await _context.Events.AddAsync(e);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("GetEventById", new { id = e.EventId }, e);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody]Event e)
        {

            if(!ModelState.IsValid || e == null)
            {
                return BadRequest(ModelState);
            }
            var existingEvent = await _context.Events.FindAsync(e.EventId);
            if (existingEvent == null)
            {
                return NotFound();
            }
            existingEvent.Name = e.Name;
            existingEvent.PointsOfInterest = e.PointsOfInterest;
            existingEvent.TicketPrice = e.TicketPrice;
            existingEvent.ZIP = e.ZIP;
            existingEvent.Description = e.Description;
            existingEvent.Address = e.Address;
            existingEvent.City = e.City;
            existingEvent.CompanyId = e.CompanyId;
            existingEvent.EventCategoryId = e.EventCategoryId;
            existingEvent.EventDate = e.EventDate;
            existingEvent.PurchaseRecords = e.PurchaseRecords;
            await _context.SaveChangesAsync();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingEvent = await _context.Events.FindAsync(id);
            if (existingEvent == null)
            {
                return NotFound();
            }
            _context.Events.Remove(existingEvent);
            await _context.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}
