using MovieAppNewVersion.Entities.Concrete;

namespace MovieAppNewVersion.DataAccess.Abstract
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Category GetCategoryByMovie(int id);
    }
}
