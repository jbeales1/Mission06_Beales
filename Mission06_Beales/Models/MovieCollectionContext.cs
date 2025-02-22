using Microsoft.EntityFrameworkCore;

namespace Mission06_Beales.Models
{
    public class MovieCollectionContext : DbContext
    {
        // creating a class (constructor) called DbContextOptions of type MovieCollectionContext that is named options
        public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base (options) 
        { 
        }

        // making a set of Movie instances. Movies is a table in the database
        public DbSet<Movie> Movies { get; set; }

        // making a set of Category instances. Categories is a table in the database
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // No seed data necessary since we are drawing from a premade database
        {

        }
    }
}
