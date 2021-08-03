using MovieAppNewVersion.Business.Abstract;
using MovieAppNewVersion.DataAccess.Abstract;
using MovieAppNewVersion.Entities.Concrete;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Business.Concrete
{
    public class MovieManager : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieManager(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<string> Create(Movie t)
        {
            return await _movieRepository.Create(t);
        }

        public async Task<string> Delete(int id)
        {
            return await _movieRepository.Delete(id);
        }

        public IQueryable<Movie> GetAll()
        {
            return _movieRepository.GetAll();
        }

        public Movie GetById(int ?id)
        {
            return _movieRepository.GetById(id);
        }

        public Movie GetMovieIncludeCategory(int id)
        {
            return  _movieRepository.GetMovieIncludeCategory(id);
        }

        public IQueryable<Movie> GetMoviesWithCategories()
        {
            return _movieRepository.GetMoviesWithCategories();
        }

        public void Save()
        {
            _movieRepository.Save();
        }
        public IQueryable<Movie>Search(string q) 
        {
            return _movieRepository.Search(q);
        }
        public async Task<string> Update(Movie t)
        {
             return await _movieRepository.Update(t);
        }

        public Movie AddCategoryToMovie(Movie movie, int[] categoryId)
        {
            return _movieRepository.AddCategoryToMovie(movie, categoryId);
        }
        public string IsMethodSuccess(int n) 
        {
            return _movieRepository.IsMethodSuccess(n);
        }

        public Task<string> EditAMovie(Movie movie, int[] categoryId)
        {
            return _movieRepository.EditAMovie(movie,categoryId);
        }

        public Task<string> CreateAMovie(Movie movie, int[] categoryId)
        {
            return _movieRepository.CreateAMovie(movie, categoryId);
        }
    }
}