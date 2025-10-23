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
    public class StatusOrdersController : ControllerBase
    {
        private readonly RhyRealm_Context _context;

        public StatusOrdersController(RhyRealm_Context context)
        {
            _context = context;
        }

        // GET: api/StatusOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusOrder>>> GetStatusOrders()
        {
            if (_context.StatusOrders == null)
            {
                return NotFound();
            }
            return await _context.StatusOrders.ToListAsync();
        }

        // GET: api/StatusOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusOrder>> GetStatusOrder(int id)
        {
            var statusOrder = await _context.StatusOrders.FindAsync(id);

            if (statusOrder == null)
            {
                return NotFound();
            }

            return statusOrder;
        }

        // PUT: api/StatusOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusOrder(int id, StatusOrder statusOrder)
        {
            if (id != statusOrder.IdStatusOrder)
            {
                return BadRequest();
            }

            _context.Entry(statusOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusOrderExists(id))
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

        // POST: api/StatusOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatusOrder>> PostStatusOrder(StatusOrder statusOrder)
        {
            _context.StatusOrders.Add(statusOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatusOrder", new { id = statusOrder.IdStatusOrder }, statusOrder);
        }

        // DELETE: api/StatusOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusOrder(int id)
        {
            var statusOrder = await _context.StatusOrders.FindAsync(id);
            if (statusOrder == null)
            {
                return NotFound();
            }

            _context.StatusOrders.Remove(statusOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusOrderExists(int id)
        {
            return _context.StatusOrders.Any(e => e.IdStatusOrder == id);
        }
    }
}
