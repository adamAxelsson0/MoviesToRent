using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace WebAPI.Models
{
    public class RentLog
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int FilmStudioId { get; set; }
        public FilmStudio FilmStudio { get; set; }
        public DateTime ExpireDate { get; set; }

        public async Task<RentLog> CheckRental(MoviesForHireContext _context)
        {
            //Dont want to find a rental that the filmstudio has made on the specified movie 
            var rental = await _context.RentLogs
            .Where(x => x.MovieId == MovieId)
            .Where(x => x.FilmStudioId == FilmStudioId).FirstOrDefaultAsync();

            if (rental != null)
            {
                return null;
            }

            var movie = await _context.Movies
            .Where(x => x.Id == this.MovieId).FirstOrDefaultAsync();

            return movie.CheckAvailability() ? this : null;
        }
        
    }
}