using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Airticket.Data;
using Airticket.Models;

namespace Airticket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactusController : ControllerBase
    {
        private readonly TicketDbContext _context;

        public ContactusController(TicketDbContext context)
        {
            _context = context;
        }

        // GET: api/Contactus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contactus>>> GetContactus()
        {
            return await _context.Contactus.ToListAsync();
        }

        // GET: api/Contactus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contactus>> GetContactus(int id)
        {
            var contactus = await _context.Contactus.FindAsync(id);

            if (contactus == null)
            {
                return NotFound();
            }

            return contactus;
        }

        // PUT: api/Contactus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactus(int id, Contactus contactus)
        {
            if (id != contactus.Cid)
            {
                return BadRequest();
            }

            _context.Entry(contactus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactusExists(id))
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

        // POST: api/Contactus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Contactus>> PostContactus(Contactus contactus)
        {
            _context.Contactus.Add(contactus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactus", new { id = contactus.Cid }, contactus);
        }

        // DELETE: api/Contactus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contactus>> DeleteContactus(int id)
        {
            var contactus = await _context.Contactus.FindAsync(id);
            if (contactus == null)
            {
                return NotFound();
            }

            _context.Contactus.Remove(contactus);
            await _context.SaveChangesAsync();

            return contactus;
        }

        private bool ContactusExists(int id)
        {
            return _context.Contactus.Any(e => e.Cid == id);
        }
    }
}
