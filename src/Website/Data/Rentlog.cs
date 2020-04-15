using System;
namespace Website.Data
{
    public class RentLog
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int FilmStudioId { get; set; }
        public FilmStudio FilmStudio { get; set; }
        public DateTime ExpireDate { get; set; }
        
    }
}