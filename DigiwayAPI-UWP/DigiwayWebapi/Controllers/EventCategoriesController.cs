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
        [Authorize]
        [Route("api/[controller]")]
        public class EventCategoriesController : Controller
        {
            private DigiwayContext _context;

            public EventCategoriesController(DigiwayContext context)
            {
                this._context = context;
            }
            // GET api/values
            [HttpGet]
            public async Task<IEnumerable<EventCategory>> Get()
            {
                return await _context.EventCategories.ToListAsync();
        }

            // GET api/values/5
            [HttpGet("id/{id}", Name = "GetEventCategoryById")]
            public async Task<IActionResult> GetById(long id)
            {
                var existingEventCategory = await _context.EventCategories
                                    .Where(e => e.EventCategoryId == id)
                                    .FirstOrDefaultAsync();
                if (existingEventCategory == null)
                {
                    return NotFound();
                }
                return new ObjectResult(existingEventCategory);
            }

            // POST api/values
            [HttpPost]
            public async Task<IActionResult> Post([FromBody]EventCategory e)
            {
                if (!ModelState.IsValid || e == null)
                {
                    return BadRequest();
                }
                await _context.EventCategories.AddAsync(e);
                await _context.SaveChangesAsync();
                return CreatedAtRoute("GetEventCategoryById", new { id = e.EventCategoryId }, e);
            }

            // PUT api/values/5
            [HttpPut]
            public async Task<IActionResult> Put(long id, [FromBody]EventCategory e)
            {
                if (!ModelState.IsValid || e == null)
                {
                    return BadRequest(ModelState);
                }
                var existingEventCategory = await _context.EventCategories.FindAsync(e.EventCategoryId);
                if (existingEventCategory == null)
                {
                    return NotFound();
                }
                existingEventCategory.Name = e.Name;
                 existingEventCategory.Events = e.Events;
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
            public async Task<IActionResult> Delete(long id)
            {
                var existingEventCategory = await _context.EventCategories.FirstOrDefaultAsync(ec => ec.EventCategoryId == id);
                 if (existingEventCategory == null)
                {
                    return NotFound();
                }
                _context.EventCategories.Remove(existingEventCategory);
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
        }
}
