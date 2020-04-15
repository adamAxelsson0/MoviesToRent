using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriviasController : ControllerBase
    {
        private readonly MoviesForHireContext _context;

        public TriviasController(MoviesForHireContext context)
        {
            _context = context;
        }

        // GET: api/Trivia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trivia>>> GetTrivias()
        {
            return await _context.Trivias.ToListAsync();
        }
        // GET: api/Trivia/FromStudio/1
        [HttpGet("FromStudio/{id}")]
        public async Task<ActionResult<IEnumerable<Trivia>>> GetTriviasFromStudio(int id)
        {
            return await _context.Trivias.Where(x => x.FilmStudioId == id).ToListAsync();
        }

        // GET: api/Trivia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trivia>> GetTrivia(int id)
        {
            var trivia = await _context.Trivias.Where(t => t.Id == id).Include(a => a.Movie).FirstOrDefaultAsync();

            if (trivia == null)
            {
                return NotFound();
            }

            return trivia;
        }

        // PUT: api/Trivia/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrivia(int id, Trivia trivia)
        {
            if (id != trivia.Id)
            {
                return BadRequest();
            }

            _context.Entry(trivia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TriviaExists(id))
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

        // POST: api/Trivia
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Trivia>> PostTrivia(Trivia trivia)
        {
            _context.Trivias.Add(trivia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrivia", new { id = trivia.Id }, trivia);
        }

        // DELETE: api/Trivia/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Trivia>> DeleteTrivia(int id)
        {
            var trivia = await _context.Trivias.FindAsync(id);
            if (trivia == null)
            {
                return NotFound();
            }

            _context.Trivias.Remove(trivia);
            await _context.SaveChangesAsync();

            return trivia;
        }

        private bool TriviaExists(int id)
        {
            return _context.Trivias.Any(e => e.Id == id);
        }
    }
}
