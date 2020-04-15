using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmStudiosController : ControllerBase
    {
        private readonly MoviesForHireContext _context;

        public FilmStudiosController(MoviesForHireContext context)
        {
            _context = context;
        }

        // GET: api/FilmStudio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmStudio>>> GetFilmStudios()
        {
            return await _context.FilmStudios.ToListAsync();
        }

        // GET: api/FilmStudio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmStudio>> GetFilmStudio(int id)
        {
            var filmStudio = await _context.FilmStudios.FindAsync(id);

            if (filmStudio == null)
            {
                return NotFound();
            }

            return filmStudio;
        }

        // PUT: api/FilmStudio/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmStudio(int id, FilmStudio filmStudio)
        {
            if (id != filmStudio.Id)
            {
                return BadRequest();
            }

            _context.Entry(filmStudio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmStudioExists(id))
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
        // [HttpPatch]
        // public IActionResult JsonPatchWithModelState([FromBody] JsonPatchDocument<FilmStudio> patchDoc)
        // {
        //     if (patchDoc != null)
        //     {
        //         var studio = new FilmStudio();

        //         patchDoc.ApplyTo(studio, ModelState);

        //         if (!ModelState.IsValid)
        //         {
        //             return BadRequest(ModelState);
        //         }

        //         return new ObjectResult(studio);
        //     }
        //     else
        //     {
        //         return BadRequest(ModelState);
        //     }
        // }

        // POST: api/FilmStudio
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<FilmStudio>> PostFilmStudio(FilmStudio filmStudio)
        {
            _context.FilmStudios.Add(filmStudio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilmStudio", new { id = filmStudio.Id }, filmStudio);
        }

        // DELETE: api/FilmStudio/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FilmStudio>> DeleteFilmStudio(int id)
        {
            var filmStudio = await _context.FilmStudios.FindAsync(id);
            if (filmStudio == null)
            {
                return NotFound();
            }

            _context.FilmStudios.Remove(filmStudio);
            await _context.SaveChangesAsync();

            return filmStudio;
        }

        private bool FilmStudioExists(int id)
        {
            return _context.FilmStudios.Any(e => e.Id == id);
        }
    }
}
