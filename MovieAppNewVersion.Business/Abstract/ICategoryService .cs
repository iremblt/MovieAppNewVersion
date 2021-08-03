using MovieAppNewVersion.Entities.Concrete;
using System.Collections.Generic;

namespace MovieAppNewVersion.Business.Abstract
{
    public interface ICategoryService:IGenericService<Category>
    {
        Category GetByIdCategoryIncludeMovie(int id);
        List<Category> GetCategoriesIncludeMovie();
    }
}