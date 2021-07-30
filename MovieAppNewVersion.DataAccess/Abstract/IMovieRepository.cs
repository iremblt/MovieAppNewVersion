using MovieAppNewVersion.Entities.Concrete;
using System.Linq;

namespace MovieAppNewVersion.DataAccess.Abstract
{
    public interface IMovieRepository:IGenericRepository<Movie>
    {
        Movie GetMovieByCategory(int id);
        IQueryable<Movie> GetMoviesWithCategories();
        IQueryable<Movie> Search(string q);
    }
}
