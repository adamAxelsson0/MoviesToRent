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
    public class RentLogsController : ControllerBase
    {
        private readonly MoviesForHireContext _context;

        public RentLogsController(MoviesForHireContext context)
        {
            _context = context;
        }

        // GET: api/RentLog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentLog>>> GetRentLogs()
        {
            return await _context.RentLogs.ToListAsync();
        }

        // GET: api/RentLog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentLog>> GetRentLog(int id)
        {
            var rentLog = await _context.RentLogs.FindAsync(id);

            if (rentLog == null)
            {
                return NotFound();
            }

            return rentLog;
        }
        
        // GET: api/Rentings/FromStudio/1
        [HttpGet("/FromStudio/{studioID}")]
        public async Task<ActionResult<IEnumerable<RentLog>>> GetMovies(int studioID)
        {
            return await _context.RentLogs.Where(x=> x.FilmStudioId == studioID).ToListAsync();
        }

        // PUT: api/RentLog/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRentLog(int id, RentLog rentLog)
        {
            if (id != rentLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(rentLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentLogExists(id))
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

        // POST: api/RentLog
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<RentLog>> PostRentLog(RentLog rentLog)
        {
            _context.RentLogs.Add(rentLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRentLog", new { id = rentLog.Id }, rentLog);
        }

        // DELETE: api/RentLog/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RentLog>> DeleteRentLog(int id)
        {
            var rentLog = await _context.RentLogs.FindAsync(id);
            if (rentLog == null)
            {
                return NotFound();
            }

            _context.RentLogs.Remove(rentLog);
            await _context.SaveChangesAsync();

            return rentLog;
        }

        private bool RentLogExists(int id)
        {
            return _context.RentLogs.Any(e => e.Id == id);
        }
    }
}
