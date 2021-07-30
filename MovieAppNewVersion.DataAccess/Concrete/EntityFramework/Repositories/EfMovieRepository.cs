using Microsoft.EntityFrameworkCore;
using MovieAppNewVersion.DataAccess.Abstract;
using MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Contexts;
using MovieAppNewVersion.Entities.Concrete;
using System.Linq;

namespace MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfMovieRepository:EfGenericRepository<Movie>,IMovieRepository
      {
        public EfMovieRepository(MovieContext context) : base(context)
        {
        }
        public Movie GetMovieByCategory(int id)
        {
            var result = _movieAppContext.Movies
                 .Include(m => m.Categories)
                 .FirstOrDefault(i => i.MovieId == id);
            return result;
        }

        public IQueryable<Movie> GetMoviesWithCategories()
        {
            return _movieAppContext.Movies.Include(i => i.Categories).AsQueryable();
        }

        public IQueryable<Movie> Search(string q) 
        {
            var search = _movieAppContext.Movies.AsQueryable();
            if (!string.IsNullOrEmpty(q))
            {
            search = search.Where(
            i => i.MovieTitle.ToLower().Contains(q.ToLower()) ||
            i.MovieDescription.ToLower().Contains(q.ToLower()) ||
            i.MovieAbout.ToLower().Contains(q.ToLower()));
            }
            return search;
        }
    }
}
