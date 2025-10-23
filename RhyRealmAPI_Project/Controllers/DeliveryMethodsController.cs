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
    public class DeliveryMethodsController : ControllerBase
    {
        private readonly RhyRealm_Context _context;

        public DeliveryMethodsController(RhyRealm_Context context)
        {
            _context = context;
        }

        // GET: api/DeliveryMethods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryMethod>>> GetDeliveryMethod()
        {
            if (_context.DeliveryMethod == null)
            {
                return NotFound();
            }
            return await _context.DeliveryMethod.ToListAsync();
        }

        // GET: api/DeliveryMethods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryMethod>> GetDeliveryMethod(int id)
        {
            var deliveryMethod = await _context.DeliveryMethod.FindAsync(id);

            if (deliveryMethod == null)
            {
                return NotFound();
            }

            return deliveryMethod;
        }

        // PUT: api/DeliveryMethods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliveryMethod(int id, DeliveryMethod deliveryMethod)
        {
            if (id != deliveryMethod.IdDeliveryMethod)
            {
                return BadRequest();
            }

            _context.Entry(deliveryMethod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryMethodExists(id))
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

        // POST: api/DeliveryMethods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeliveryMethod>> PostDeliveryMethod(DeliveryMethod deliveryMethod)
        {
            _context.DeliveryMethod.Add(deliveryMethod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeliveryMethod", new { id = deliveryMethod.IdDeliveryMethod }, deliveryMethod);
        }

        // DELETE: api/DeliveryMethods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryMethod(int id)
        {
            var deliveryMethod = await _context.DeliveryMethod.FindAsync(id);
            if (deliveryMethod == null)
            {
                return NotFound();
            }

            _context.DeliveryMethod.Remove(deliveryMethod);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeliveryMethodExists(int id)
        {
            return _context.DeliveryMethod.Any(e => e.IdDeliveryMethod == id);
        }
    }
}
