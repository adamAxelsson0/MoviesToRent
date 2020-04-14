using System;
namespace Website.Data
{
    public class Trivia
    {
        public int Id { get; set; }
        public string TriviaText { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int FilmStudioId { get; set; }
        public FilmStudio FilmStudio { get; set; }
    }
}