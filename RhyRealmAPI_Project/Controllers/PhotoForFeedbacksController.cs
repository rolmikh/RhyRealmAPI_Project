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
    public class PhotoForFeedbacksController : ControllerBase
    {
        private readonly RhyRealm_Context _context;

        public PhotoForFeedbacksController(RhyRealm_Context context)
        {
            _context = context;
        }

        // GET: api/PhotoForFeedbacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhotoForFeedback>>> GetPhotoForFeedbacks()
        {
            if (_context.PhotoForFeedbacks == null)
            {
                return NotFound();
            }
            return await _context.PhotoForFeedbacks.ToListAsync();
        }

        // GET: api/PhotoForFeedbacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoForFeedback>> GetPhotoForFeedback(int id)
        {
            var photoForFeedback = await _context.PhotoForFeedbacks.FindAsync(id);

            if (photoForFeedback == null)
            {
                return NotFound();
            }

            return photoForFeedback;
        }

        // PUT: api/PhotoForFeedbacks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhotoForFeedback(int id, PhotoForFeedback photoForFeedback)
        {
            if (id != photoForFeedback.IdPhotoForFeedback)
            {
                return BadRequest();
            }

            _context.Entry(photoForFeedback).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoForFeedbackExists(id))
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

        // POST: api/PhotoForFeedbacks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhotoForFeedback>> PostPhotoForFeedback(PhotoForFeedback photoForFeedback)
        {
            _context.PhotoForFeedbacks.Add(photoForFeedback);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhotoForFeedback", new { id = photoForFeedback.IdPhotoForFeedback }, photoForFeedback);
        }

        // DELETE: api/PhotoForFeedbacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhotoForFeedback(int id)
        {
            var photoForFeedback = await _context.PhotoForFeedbacks.FindAsync(id);
            if (photoForFeedback == null)
            {
                return NotFound();
            }

            _context.PhotoForFeedbacks.Remove(photoForFeedback);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhotoForFeedbackExists(int id)
        {
            return _context.PhotoForFeedbacks.Any(e => e.IdPhotoForFeedback == id);
        }
    }
}
