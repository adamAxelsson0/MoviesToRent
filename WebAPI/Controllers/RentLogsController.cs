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
        // GET: api/RentLog/FromStudio/1
        [HttpGet("FromStudio/{id}")]
        public async Task<ActionResult<IEnumerable<RentLog>>> GetRentLogsFromStudio(int id)
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
            rentLog = await rentLog.CheckRental(_context);

            if (rentLog != null)
            {
                //need to check since our get wont always include a Movie(if it was posted by postman for example)
                //need to double check with rentlogs movieid prop to get movie
                var movie = await _context.Movies.FindAsync(rentLog.MovieId);
                movie = movie.Rental();

                _context.RentLogs.Add(rentLog);
                _context.Entry(movie).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetrentLog", new { id = rentLog.Id }, rentLog);
            }

            throw new InvalidOperationException("The rental could not be completed.");
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

            var movie = await _context.Movies.FindAsync(rentLog.MovieId);
            movie = movie.RentalReturn();

            _context.RentLogs.Remove(rentLog);
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return rentLog;
        }

        private bool RentLogExists(int id)
        {
            return _context.RentLogs.Any(e => e.Id == id);
        }
    }
}
