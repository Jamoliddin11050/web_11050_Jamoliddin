using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _11050_workshop.Data;
using _11050_workshop.Models;

namespace _11050_workshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class publishersController : ControllerBase
    {
        private readonly BookShopDbContext _context;

        public publishersController(BookShopDbContext context)
        {
            _context = context;
        }

        // GET: api/publishers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<publisher>>> Getpublishers()
        {
          if (_context.publishers == null)
          {
              return NotFound();
          }
            return await _context.publishers.ToListAsync();
        }

        // GET: api/publishers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<publisher>> Getpublisher(int id)
        {
          if (_context.publishers == null)
          {
              return NotFound();
          }
            var publisher = await _context.publishers.FindAsync(id);

            if (publisher == null)
            {
                return NotFound();
            }

            return publisher;
        }

        // PUT: api/publishers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpublisher(int id, publisher publisher)
        {
            if (id != publisher.Id)
            {
                return BadRequest();
            }

            _context.Entry(publisher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!publisherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/publishers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<publisher>> Postpublisher(publisher publisher)
        {
          if (_context.publishers == null)
          {
              return Problem("Entity set 'BookShopDbContext.publishers'  is null.");
          }
            _context.publishers.Add(publisher);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpublisher", new { id = publisher.Id }, publisher);
        }

        // DELETE: api/publishers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletepublisher(int id)
        {
            if (_context.publishers == null)
            {
                return NotFound();
            }
            var publisher = await _context.publishers.FindAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }

            _context.publishers.Remove(publisher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool publisherExists(int id)
        {
            return (_context.publishers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
