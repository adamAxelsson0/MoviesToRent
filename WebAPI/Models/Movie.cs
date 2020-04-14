using System.Net.Http;
using System;
namespace WebAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public bool CheckAvailability()
        {
            if (Quantity > 0) { return true; }
            return false;
        }
        public Movie Rental()
        {
            this.Quantity -= 1;
            return this;
        }
        public Movie RentalReturn()
        {
            this.Quantity += 1;
            return this;
        }
    }
}