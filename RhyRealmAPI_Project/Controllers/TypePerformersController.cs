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
    public class TypePerformersController : ControllerBase
    {
        private readonly RhyRealm_Context _context;

        public TypePerformersController(RhyRealm_Context context)
        {
            _context = context;
        }

        // GET: api/TypePerformers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypePerformer>>> GetTypePerformers()
        {
            if (_context.TypePerformers == null)
            {
                return NotFound();
            }
            return await _context.TypePerformers.ToListAsync();
        }

        // GET: api/TypePerformers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypePerformer>> GetTypePerformer(int id)
        {
            var typePerformer = await _context.TypePerformers.FindAsync(id);

            if (typePerformer == null)
            {
                return NotFound();
            }

            return typePerformer;
        }

        // PUT: api/TypePerformers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypePerformer(int id, TypePerformer typePerformer)
        {
            if (id != typePerformer.IdTypePerformer)
            {
                return BadRequest();
            }

            _context.Entry(typePerformer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypePerformerExists(id))
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

        // POST: api/TypePerformers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypePerformer>> PostTypePerformer(TypePerformer typePerformer)
        {
            _context.TypePerformers.Add(typePerformer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypePerformer", new { id = typePerformer.IdTypePerformer }, typePerformer);
        }

        // DELETE: api/TypePerformers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypePerformer(int id)
        {
            var typePerformer = await _context.TypePerformers.FindAsync(id);
            if (typePerformer == null)
            {
                return NotFound();
            }

            _context.TypePerformers.Remove(typePerformer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypePerformerExists(int id)
        {
            return _context.TypePerformers.Any(e => e.IdTypePerformer == id);
        }
    }
}
