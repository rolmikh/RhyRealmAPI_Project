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
    public class ContentAlbumsController : ControllerBase
    {
        private readonly RhyRealm_Context _context;

        public ContentAlbumsController(RhyRealm_Context context)
        {
            _context = context;
        }

        // GET: api/ContentAlbums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContentAlbum>>> GetContentAlbums()
        {
            if (_context.ContentAlbums == null)
            {
                return NotFound();
            }
            return await _context.ContentAlbums.ToListAsync();
        }

        // GET: api/ContentAlbums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContentAlbum>> GetContentAlbum(int id)
        {
            var contentAlbum = await _context.ContentAlbums.FindAsync(id);

            if (contentAlbum == null)
            {
                return NotFound();
            }

            return contentAlbum;
        }

        // PUT: api/ContentAlbums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContentAlbum(int id, ContentAlbum contentAlbum)
        {
            if (id != contentAlbum.IdContentAlbum)
            {
                return BadRequest();
            }

            _context.Entry(contentAlbum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentAlbumExists(id))
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

        // POST: api/ContentAlbums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContentAlbum>> PostContentAlbum(ContentAlbum contentAlbum)
        {
            _context.ContentAlbums.Add(contentAlbum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContentAlbum", new { id = contentAlbum.IdContentAlbum }, contentAlbum);
        }

        // DELETE: api/ContentAlbums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContentAlbum(int id)
        {
            var contentAlbum = await _context.ContentAlbums.FindAsync(id);
            if (contentAlbum == null)
            {
                return NotFound();
            }

            _context.ContentAlbums.Remove(contentAlbum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContentAlbumExists(int id)
        {
            return _context.ContentAlbums.Any(e => e.IdContentAlbum == id);
        }
    }
}
