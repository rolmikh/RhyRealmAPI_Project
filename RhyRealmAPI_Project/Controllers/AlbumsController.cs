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
    public class AlbumsController : ControllerBase
    {
        private readonly RhyRealm_Context _context;

        public AlbumsController(RhyRealm_Context context)
        {
            _context = context;
        }

        // GET: api/Albums for admin
        [HttpGet("/ActiveAlbums")]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            if (_context.Albums == null)
            {
                return NotFound();
            }
            var albums = await _context.Albums.Where(n => n.IsDeleted == true).ToListAsync();


            return albums;
        }

        // GET: api/Albums for admin archive
        [HttpGet("/Archive")]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbumsArchive()
        {
            if (_context.Albums == null)
            {
                return NotFound();
            }

            var albums = _context.Albums.Where(n => n.IsDeleted == false);
            return await albums.ToListAsync();
        }

        // GET: api/Albums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            var album = await _context.Albums.FindAsync(id);

            if (album == null)
            {
                return NotFound();
            }

            return album;
        }

        // PUT: api/Albums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlbum(int id, Album album)
        {
            if (id != album.IdAlbum)
            {
                return BadRequest();
            }

            _context.Entry(album).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(id))
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

        // POST: api/Albums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Album>> PostAlbum(Album album)
        {
            _context.Albums.Add(album);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlbum", new { id = album.IdAlbum }, album);
        }

        // DELETE: api/Albums/5

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.IdAlbum == id);
        }

        //Filter: api/Albums/Filter/5
        [HttpGet("Filter/{idPerformer}")]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbumByPerformer(int idPerformer)
        {
            var albums = await _context.Albums.Where(n => n.PerformerId == idPerformer).ToListAsync();

            if (albums == null)
            {
                return NotFound();
            }

            return albums;
        }

        //SearchByName: api/Albums/
        [HttpGet("Search/{request}")]
        public async Task<ActionResult<IEnumerable<Album>>> SearchAlbum(string request)
        {
            if (request == null)
            {
                return NotFound();
            }
            var albums = await _context.Albums.Where(n => n.NameAlbum.Contains(request)).ToListAsync();

            if (albums == null)
            {
                return NotFound();
            }

            return albums;
        }

       




    }
}
