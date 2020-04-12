using System.Net.Http;
namespace WebAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public bool CheckMovie()
        {
            if (CheckAvailability()) { return true; }
            return false;
        }
        public bool CheckAvailability()
        {
            if (Quantity > 0) { return true; }
            return false;
        }
    }
}