using Microsoft.AspNetCore.Http;
using MovieAppNewVersion.Entities.Concrete;
using System.Linq;
namespace MovieAppNewVersion.DataAccess.Abstract
{
    public interface IMovieRepository:IGenericRepository<Movie>
    {
        Movie GetMovieIncludeCategory(int id);
        IQueryable<Movie> GetMoviesWithCategories();
        Movie AddCategoryToMovie(Movie movie, int[] categoryId);
        Movie AddImageFileToMovie(IFormFile file, Movie movie);
    }
}
