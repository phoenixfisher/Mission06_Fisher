using Microsoft.EntityFrameworkCore;
using Mission06_Fisher.Models;

namespace Mission06_Fisher.Data;

using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Director> Directors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed sample categories and directors (so FK constraints are satisfied)
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Drama" },
            new Category { Id = 2, Name = "Comedy" },
            new Category { Id = 3, Name = "Sci-Fi" }
        );

        modelBuilder.Entity<Director>().HasData(
            new Director { Id = 1, Name = "Christopher Nolan" },
            new Director { Id = 2, Name = "Hayao Miyazaki" },
            new Director { Id = 3, Name = "Greta Gerwig" }
        );

        // Seed three favorite movies (assignment requires at least three)
        modelBuilder.Entity<Movie>().HasData(
            new Movie {
                Id = 1,
                CategoryId = 3, // Sci-Fi
                Title = "Inception",
                Year = "2010",
                DirectorId = 1,
                Rating = Rating.PG13,
                Edited = false,
                LentTo = null,
                Notes = "My fav",
                DateAdded = DateTime.UtcNow
            },
            new Movie {
                Id = 2,
                CategoryId = 2, // Comedy
                Title = "My Neighbor Totoro",
                Year = "1988",
                DirectorId = 2,
                Rating = Rating.G,
                Edited = false,
                LentTo = null,
                Notes = "Comfort watch",
                DateAdded = DateTime.UtcNow
            },
            new Movie {
                Id = 3,
                CategoryId = 1, // Drama
                Title = "Little Women",
                Year = "2019",
                DirectorId = 3,
                Rating = Rating.PG,
                Edited = false,
                LentTo = null,
                Notes = "Greta's film",
                DateAdded = DateTime.UtcNow
            }
        );
    }
}