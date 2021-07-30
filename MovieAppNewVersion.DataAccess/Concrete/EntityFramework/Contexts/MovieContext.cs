using Microsoft.EntityFrameworkCore;
using MovieAppNewVersion.Entities.Concrete;

namespace MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Contexts
{
    public class MovieContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=moviesDB;integrated security=true;");
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Directors { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Vote> Votes { get; set; }

    }
}
