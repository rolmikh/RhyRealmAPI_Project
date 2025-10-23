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
    public class ContentOrdersController : ControllerBase
    {
        private readonly RhyRealm_Context _context;

        public ContentOrdersController(RhyRealm_Context context)
        {
            _context = context;
        }

        // GET: api/ContentOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContentOrder>>> GetContentOrders()
        {
            if (_context.ContentOrders == null)
            {
                return NotFound();
            }
            return await _context.ContentOrders.ToListAsync();
        }

        // GET: api/ContentOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContentOrder>> GetContentOrder(int id)
        {
            var contentOrder = await _context.ContentOrders.FindAsync(id);

            if (contentOrder == null)
            {
                return NotFound();
            }

            return contentOrder;
        }

        // PUT: api/ContentOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContentOrder(int id, ContentOrder contentOrder)
        {
            if (id != contentOrder.IdContentOrder)
            {
                return BadRequest();
            }

            _context.Entry(contentOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentOrderExists(id))
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

        // POST: api/ContentOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContentOrder>> PostContentOrder(ContentOrder contentOrder)
        {
            _context.ContentOrders.Add(contentOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContentOrder", new { id = contentOrder.IdContentOrder }, contentOrder);
        }

        // DELETE: api/ContentOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContentOrder(int id)
        {
            var contentOrder = await _context.ContentOrders.FindAsync(id);
            if (contentOrder == null)
            {
                return NotFound();
            }

            _context.ContentOrders.Remove(contentOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContentOrderExists(int id)
        {
            return _context.ContentOrders.Any(e => e.IdContentOrder == id);
        }
    }
}
