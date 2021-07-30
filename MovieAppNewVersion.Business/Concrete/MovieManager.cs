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
        public async Task<Movie> Add(Movie t)
        {
            return await _movieRepository.Add(t);
        }

        public async Task<Movie> Delete(int id)
        {
            return await _movieRepository.Delete(id);
        }
        public IQueryable<Movie> GetAll()
        {
            return _movieRepository.GetAll();
        }

        public Movie GetById(int id)
        {
            return _movieRepository.GetById(id);
        }

        public Movie GetMovieByCategory(int id)
        {
            return  _movieRepository.GetMovieByCategory(id);
        }

        public IQueryable<Movie> GetMoviesWithCategories()
        {
            return _movieRepository.GetMoviesWithCategories();
        }

        public void Save()
        {
            _movieRepository.Save();
        }

        public IQueryable<Movie> Search(string q)
        {
            return _movieRepository.Search(q);
        }

        public async Task<Movie> Update(Movie t)
        {
            return await _movieRepository.Update(t);
        }
    }
}