using Microsoft.EntityFrameworkCore;
using MovieAppNewVersion.DataAccess.Abstract;
using MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Contexts;
using MovieAppNewVersion.Entities.Concrete;
using System.Linq;

namespace MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfCategoryRepository:EfGenericRepository<Category>,ICategoryRepository
    {
        public EfCategoryRepository(MovieContext context) : base(context)
        {
        }

        public Category GetCategoryByMovie(int id)
        {
            var result = _movieAppContext.Categories
                 .Include(m => m.Movies)
                 .FirstOrDefault(i => i.CategoryId == id);
            return result;
        }
    }
}
