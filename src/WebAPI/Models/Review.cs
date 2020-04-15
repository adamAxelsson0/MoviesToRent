using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace WebAPI.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int FilmStudioId { get; set; }
        public FilmStudio FilmStudio { get; set; }
        private bool CheckRating()
        {
            if (this.Rating > 0 && this.Rating < 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<Review> ReviewMovie(MoviesForHireContext _context)
        {
            //Check if rating is 1-5
            if(!CheckRating()){return null;}

            //Dont want to find a review that the filmstudio has made on the specified movie 
            var review = await _context.Reviews
            .Where(x => x.MovieId == MovieId)
            .Where(x => x.FilmStudioId == FilmStudioId).FirstOrDefaultAsync();

            if (review != null)
            {
                return null;
            }

            return this;
        }
    }
}