namespace WebAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageURL {get;set;}
        public double Rating{get;set;}
        public string Description {get;set;}

    }
}