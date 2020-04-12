using Microsoft.EntityFrameworkCore;
namespace WebAPI.Models
{
     public class MoviesForHireContext : DbContext
    {
        /*public MoviesForHireContext(DbContextOptions<MoviesForHireContext> options)
            : base(options)
        {
        }*/
        protected override void OnConfiguring (DbContextOptionsBuilder options){
            options.UseSqlite("Data Source =movieRentingDb.db");
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<FilmStudio> FilmStudios { get; set; }
        public DbSet<RentLog> RentLogs { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Trivia> Trivias { get; set; }
    }
}