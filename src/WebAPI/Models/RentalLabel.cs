using System;
namespace WebAPI.Models
{
    public class RentalLabel
    {
        public string Title { get; set; }
        public string Location {get;set;}
        public DateTime ExpireDate{get;set;}
    }
}