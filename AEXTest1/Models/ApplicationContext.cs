using Microsoft.EntityFrameworkCore;

namespace AEXTest1.Models
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Movie> Movies { get; set; } = null!;

        public DbSet<Actor> Actors { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
