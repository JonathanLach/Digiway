using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DigiwayWebapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Collections;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace DigiwayWebapi.Controllers
{
    [Authorize]
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
                    .Include(ec => ec.Location)
                    .Include(poi => poi.PointsOfInterest)
                    .Include(c => c.Company)
                    .ToListAsync();
        }

        [HttpPut("idList")]
        public async Task<IEnumerable<Event>> Get([FromBody]List<IdFilter> ids) {
            List<Event> events = new List<Event>();
            foreach(IdFilter id in ids) {
                var existingEvent = await _context.Events
                                    .Include(ec => ec.EventCategory)
                                    .Include(ec => ec.Location)
                                    .Include(poi => poi.PointsOfInterest)
                                    .Include(c => c.Company)
                                    .Where(ev => ev.EventId == id.Id)
                                    .FirstOrDefaultAsync();
                if(existingEvent != null)
                {
                    events.Add(existingEvent);
                }
            }
            return events;
        }

        // GET api/values/5
        [HttpGet("id/{id}", Name = "GetEventById")]
        public async Task<IActionResult> GetEventById(long id)
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

        [HttpGet("incoming")]
        public async Task<IEnumerable<Event>> GetFutureEvents()
        {
            return await _context.Events
                             .Where(e => e.EventDate >= DateTime.Today)
                            .Include(ec => ec.EventCategory)
                            .Include(poi => poi.PointsOfInterest)
                            .Include(c => c.Company)
                            .ToListAsync();
        }

        [HttpGet("poi/{id}", Name = "GetPOIFromEventById")]
        public async Task<IEnumerable<PointOfInterest>> GetPOIFromEventById(long id)
        {
            return await _context.PointsOfInterest
                    .Where(poi => poi.Event.EventId == id)
                    .ToListAsync();
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
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return StatusCode((int)HttpStatusCode.Conflict);
            }
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("id/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingEvent = await _context.Events.FirstOrDefaultAsync(e => e.EventId == id);
            if (existingEvent == null)
            {
                return NotFound();
            }
            _context.Events.Remove(existingEvent);
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
