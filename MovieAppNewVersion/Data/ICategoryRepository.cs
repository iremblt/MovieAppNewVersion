using MovieAppNewVersion.Entity;
using MovieAppNewVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Data
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetCategories();
        Task<Category> DeleteCategory(int id);
        Task<Category> EditCategory(UpdateCategory category);
        Category Id(int id);
        void SaveChanges();
    }
}
