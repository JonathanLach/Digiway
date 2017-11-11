using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DigiwayModel;
using Microsoft.EntityFrameworkCore;
using System.Web;

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
        [HttpGet("{id}")]
        public async Task<IQueryable<Event>> Get(int id)
        {
            return await Task.FromResult(_context.Events.Where(e => e.EventId == id)
                    .Include(ec => ec.EventCategory)
                    .Include(poi => poi.PointsOfInterest)
                    .Include(c => c.Company));
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]Event e)
        {
            if (ModelState.IsValid) {
                await _context.Events.AddAsync(e);
                await _context.SaveChangesAsync();
            }
        }

        // PUT api/values/5
        [HttpPut]
        public async Task Put(int id, [FromBody]Event e)
        {
            if(ModelState.IsValid)
            {
                var existingEvent = await _context.Events.FindAsync(e.EventId);
                if(existingEvent != null)
                {
                    existingEvent.Name = e.Name;
                    existingEvent.PointsOfInterest = e.PointsOfInterest;
                    existingEvent.TicketPrice = e.TicketPrice;
                    existingEvent.ZIP = e.ZIP;
                    existingEvent.Description = e.Description;
                    existingEvent.Address = e.Address;
                    existingEvent.City = e.City;
                    existingEvent.Company = e.Company;
                    existingEvent.EventCategory = e.EventCategory;
                    existingEvent.EventDate = e.EventDate;
                    existingEvent.PurchaseRecords = e.PurchaseRecords;
                    await _context.SaveChangesAsync();
                }
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var existingEvent = await _context.Events.FindAsync(id);
            if (existingEvent != null)
            {
                _context.Events.Remove(existingEvent);
                await _context.SaveChangesAsync();
            }
        }
    }
}
