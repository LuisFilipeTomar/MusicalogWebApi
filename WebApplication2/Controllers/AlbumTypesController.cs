using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumTypesController : ControllerBase
    {
        private readonly MusicalogContext _context;

        public AlbumTypesController(MusicalogContext context)
        {
            _context = context;
        }

        // GET: api/AlbumTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlbumType>>> GetAlbumTypes()
        {
            return await _context.AlbumTypes.ToListAsync();
        }

        // GET: api/AlbumTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlbumType>> GetAlbumType(int id)
        {
            var albumType = await _context.AlbumTypes.FindAsync(id);

            if (albumType == null)
            {
                return NotFound();
            }

            return albumType;
        }

        // PUT: api/AlbumTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlbumType(int id, AlbumType albumType)
        {
            if (id != albumType.Album_TypeID)
            {
                return BadRequest();
            }

            _context.Entry(albumType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumTypeExists(id))
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

        // POST: api/AlbumTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AlbumType>> PostAlbumType(AlbumType albumType)
        {
            _context.AlbumTypes.Add(albumType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlbumType", new { id = albumType.Album_TypeID }, albumType);
        }

        // DELETE: api/AlbumTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbumType(int id)
        {
            var albumType = await _context.AlbumTypes.FindAsync(id);
            if (albumType == null)
            {
                return NotFound();
            }

            _context.AlbumTypes.Remove(albumType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlbumTypeExists(int id)
        {
            return _context.AlbumTypes.Any(e => e.Album_TypeID == id);
        }
    }
}
