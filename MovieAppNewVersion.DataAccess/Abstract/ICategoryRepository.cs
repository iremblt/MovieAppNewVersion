using MovieAppNewVersion.Entities.Concrete;
using System.Collections.Generic;

namespace MovieAppNewVersion.DataAccess.Abstract
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Category GetByIdCategoryIncludeMovie(int id);
        List<Category> GetCategoriesIncludeMovies();
    }
}
