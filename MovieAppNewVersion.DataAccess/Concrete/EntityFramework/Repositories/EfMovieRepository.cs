using Microsoft.EntityFrameworkCore;
using MovieAppNewVersion.DataAccess.Abstract;
using MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Contexts;
using MovieAppNewVersion.Entities.Concrete;
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
        public IQueryable<Movie>Search(string q) 
        {
            var search = _movieAppContext.Movies.AsQueryable();
            search = search.Where(i=>i.MovieAbout.Contains(q.ToLower())||i.MovieDescription.Contains(q.ToLower())
            ||i.MovieTitle.Contains(q.ToLower()));
            return search;
        }
        public async Task<string> CreateAMovie(Movie movie, int[] categoryId)
        {
             AddCategoryToMovie(movie, categoryId);
             string message= await Create(movie);
             return message;
        }
        public async Task<string> EditAMovie(Movie movie, int[] categoryId)
        {
            AddCategoryToMovie(movie, categoryId);
            string message= await Update(movie);
            return message;
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
    }
}
