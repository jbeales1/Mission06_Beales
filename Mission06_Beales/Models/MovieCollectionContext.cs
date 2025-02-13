using Microsoft.EntityFrameworkCore;

namespace Mission06_Beales.Models
{
    public class MovieCollectionContext : DbContext
    {
        // creating a class (constructor) called DbContextOptions of type MovieCollectionContext that is named options
        public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base (options) 
        { 
        }

        // making a set of Movie instances. Movies will be the name of the database.
        public DbSet<Movie> Movies { get; set; }
    }
}
