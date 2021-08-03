using MovieAppNewVersion.Entities.Concrete;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.DataAccess.Abstract
{
    public interface IMovieRepository:IGenericRepository<Movie>
    {
        Movie GetMovieIncludeCategory(int id);
        IQueryable<Movie> GetMoviesWithCategories();
        IQueryable<Movie> Search(string q);
        Movie AddCategoryToMovie(Movie movie, int[] categoryId);
        Task<string> EditAMovie(Movie movie, int[] categoryId);
        Task<string> CreateAMovie(Movie movie, int[] categoryId);
    }
}
