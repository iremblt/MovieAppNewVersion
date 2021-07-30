using MovieAppNewVersion.Entities.Concrete;
using System.Linq;

namespace MovieAppNewVersion.Business.Abstract
{
    public interface IMovieService:IGenericService<Movie>
    {
        Movie GetMovieByCategory(int id);
        IQueryable<Movie> GetMoviesWithCategories();
        IQueryable<Movie> Search(string q);
    }
}
