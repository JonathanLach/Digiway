using DigiwayWebapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DigiwayWebapi.Controllers
{
    namespace DigiwayWebapi.Controllers
    {
        [Authorize]
        [Route("api/[controller]")]
        public class PointsOfInterestController : Controller
        {
            private DigiwayContext _context;

            public PointsOfInterestController(DigiwayContext context)
            {
                this._context = context;
            }
            // GET api/values
            [HttpGet]
            public async Task<IEnumerable<PointOfInterest>> Get()
            {
                return await _context.PointsOfInterest.Include(poi => poi.Event)
                                                      .ToListAsync();
            }

            // GET api/values/5
            [HttpGet("id/{id}", Name = "GetPOIById")]
            public async Task<IActionResult> GetPOIById(long id)
            {
                var existingPOI = await _context.PointsOfInterest.Include(poi => poi.Event)
                                                                .Where(poi => poi.PointOfInterestId == id)
                                                                .FirstOrDefaultAsync();
                if (existingPOI == null)
                {
                    return NotFound();
                }
                return new ObjectResult(existingPOI);
            }


            // GET api/values/5
            [HttpGet("eventid/{id}", Name = "GetPOIByEventId")]
            public async Task<IEnumerable<PointOfInterest>> GetPOIByEventId(long id)
            {
                return await _context.PointsOfInterest.Include(poi => poi.Event)
                                                        .Where(poi => poi.Event.EventId == id)
                                                        .ToListAsync();
            }

            // POST api/values
            [HttpPost]
            public async Task<IActionResult> Post([FromBody]PointOfInterest poi)
            {
                if (!ModelState.IsValid || poi == null)
                {
                    return BadRequest();
                }
                await _context.PointsOfInterest.AddAsync(poi);
                await _context.SaveChangesAsync();
                return CreatedAtRoute("GetPOIById", new { id = poi.PointOfInterestId }, poi);
            }

            // PUT api/values/5
            [HttpPut]
            public async Task<IActionResult> Put(int id, [FromBody]PointOfInterest poi)
            {

                if (!ModelState.IsValid || poi == null)
                {
                    return BadRequest(ModelState);
                }
                var existingPOI = await _context.PointsOfInterest.FindAsync(poi.PointOfInterestId);
                if (existingPOI == null)
                {
                    return NotFound();
                }
                existingPOI.Description = poi.Description;
                existingPOI.Event = poi.Event;
                existingPOI.Latitude = poi.Latitude;
                existingPOI.Longitude = poi.Longitude;
                existingPOI.Name = poi.Name;
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
            public async Task<IActionResult> Delete(int id)
            {
                var existingPOI = await _context.PointsOfInterest.FirstOrDefaultAsync(poi => poi.PointOfInterestId == id);
                if (existingPOI == null)
                {
                    return NotFound();
                }
                _context.PointsOfInterest.Remove(existingPOI);
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

}
