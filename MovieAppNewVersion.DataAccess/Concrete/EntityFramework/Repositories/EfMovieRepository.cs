using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieAppNewVersion.DataAccess.Abstract;
using MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Contexts;
using MovieAppNewVersion.Entities.Concrete;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfMovieRepository : EfGenericRepository<Movie>, IMovieRepository
    {
        private readonly ICategoryRepository _categoryRepository;
        public EfMovieRepository(MovieContext context ,ICategoryRepository categoryRepository) : base(context)
        {
            _categoryRepository = categoryRepository;
        }
        public Movie GetMovieIncludeCategory(int id)
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
        public Movie AddCategoryToMovie(Movie movie, int[] categoryId)
        {
            if (categoryId != null)
            {
                foreach (var id in categoryId)
                {
                    movie.Categories.Add(_categoryRepository.GetById(id));
                }
            }
            return movie;
        }
        public Movie AddImageFileToMovie(IFormFile file,Movie movie)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);
            movie.MovieImage = file.FileName;
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return movie;
        }
    }
}
