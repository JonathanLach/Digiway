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
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
