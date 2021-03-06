﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DigiwayWebapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace DigiwayWebapi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class TransferRecordsController : Controller
    {
        private DigiwayContext _context;

        public TransferRecordsController(DigiwayContext context)
        {
            this._context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<TransferRecord>> Get()
        {
            return await _context.TransferRecords.Include(ar => ar.ActionRecord).ThenInclude(u => u.User).ToListAsync();
        }

        // GET api/values/5
        [HttpGet("id/{id}", Name ="GetTransferById")]
        public async Task<IActionResult> GetById(long id)
        {
            var existingTransferRecord = await _context.TransferRecords.Include(ar => ar.ActionRecord).FirstOrDefaultAsync();
            if (existingTransferRecord == null)
            {
                return NotFound();
            }
            return new ObjectResult(existingTransferRecord);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TransferRecord transferRecord)
        {
            if (!ModelState.IsValid || transferRecord == null)
            {
                return BadRequest();
            }
            await _context.TransferRecords.AddAsync(transferRecord);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("GetTransferById", new {id = transferRecord.TransferRecordId }, transferRecord);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put(long id, [FromBody]TransferRecord transferRecord)
        {
            if (!ModelState.IsValid || transferRecord == null)
            {
                return BadRequest(ModelState);
            }
            var existingTransferRecord = await _context.TransferRecords.FindAsync(transferRecord.TransferRecordId);
            if (existingTransferRecord == null)
            {
                return NotFound();
            }
            existingTransferRecord.ActionRecord = transferRecord.ActionRecord;
            existingTransferRecord.TransferedValue = transferRecord.TransferedValue;
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
            var existingTransferRecord = await _context.TransferRecords.FirstOrDefaultAsync(tr => tr.TransferRecordId == id);

            if (existingTransferRecord == null)
            {
                return NotFound();
            }
            _context.TransferRecords.Remove(existingTransferRecord);
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
