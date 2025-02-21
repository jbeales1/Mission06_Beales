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

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Seed data
        {
            modelBuilder.Entity<Movie>().HasData(

                new Category { CategoryId = 1, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 2, CategoryName = "Drama" },
                new Category { CategoryId = 3, CategoryName = "Television"},
                new Category { CategoryId = 4, CategoryName = "Horror/Suspense"},
                new Category { CategoryId = 5, CategoryName = "Comedy"},
                new Category { CategoryId = 6, CategoryName = "Family"},
                new Category { CategoryId = 7, CategoryName = "Action/Adventure"},
                new Category { CategoryId = 8, CategoryName = "VHS"}
                );

        }
    }
}
