using Microsoft.EntityFrameworkCore;
using MovieAppNewVersion.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Data
{
    public class MovieContext:DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Directors { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Cast>  Casts { get; set; }
       // public DbSet<Vote> Votes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().Property(b => b.MovieTitle).IsRequired();
            modelBuilder.Entity<Movie>().Property(b => b.MovieTitle).HasMaxLength(500);
         //   modelBuilder.Entity<Category>().Property(b => b.Name).IsRequired();
        //    modelBuilder.Entity<Category>().Property(b => b.Name).HasMaxLength(50);
        }
    }
}
