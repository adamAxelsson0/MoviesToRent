namespace WebAPI.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int MovieId { get; set; }
        public int FilmStudioId { get; set; }
    }
}