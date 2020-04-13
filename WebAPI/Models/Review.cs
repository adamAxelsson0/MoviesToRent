using System;
namespace WebAPI.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int MovieId {get;set;}
        public Movie Movie{get;set;}
        public int FilmStudioId { get; set; }
        public FilmStudio FilmStudio {get;set;}
        public DateTime ExpireDate { get; set; }
    }
}