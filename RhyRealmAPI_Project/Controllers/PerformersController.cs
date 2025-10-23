using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RhyRealmAPI_Project.Models;

namespace RhyRealmAPI_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformersController : ControllerBase
    {
        private readonly RhyRealm_Context _context;

        public PerformersController(RhyRealm_Context context)
        {
            _context = context;
        }

        // GET: api/Performers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Performer>>> GetPerformers()
        {
            if (_context.Performers == null)
            {
                return NotFound();
            }
            return await _context.Performers.ToListAsync();
        }

        // GET: api/Performers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Performer>> GetPerformer(int id)
        {
            var performer = await _context.Performers.FindAsync(id);

            if (performer == null)
            {
                return NotFound();
            }

            return performer;
        }

        // PUT: api/Performers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerformer(int id, Performer performer)
        {
            if (id != performer.IdPerformer)
            {
                return BadRequest();
            }

            _context.Entry(performer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerformerExists(id))
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

        // POST: api/Performers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Performer>> PostPerformer(Performer performer)
        {
            _context.Performers.Add(performer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerformer", new { id = performer.IdPerformer }, performer);
        }

        // DELETE: api/Performers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerformer(int id)
        {
            var performer = await _context.Performers.FindAsync(id);
            if (performer == null)
            {
                return NotFound();
            }

            _context.Performers.Remove(performer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PerformerExists(int id)
        {
            return _context.Performers.Any(e => e.IdPerformer == id);
        }

        // GET: api/Performers/Filter/5
        [HttpGet("Filter/{idTypePerformer}")]
        public async Task<ActionResult<IEnumerable<Performer>>> GetPerformerByType(int idTypePerformer)
        {
            var performer = await _context.Performers.Where(n => n.TypePerformerId == idTypePerformer).ToListAsync();

            if (performer == null)
            {
                return NotFound();
            }

            return performer;
        }
    }
}
