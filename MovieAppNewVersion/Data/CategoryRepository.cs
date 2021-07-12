using Microsoft.EntityFrameworkCore;
using MovieAppNewVersion.Entity;
using MovieAppNewVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private MovieContext _movieContext;
        public CategoryRepository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public Category Id(int id)
        {
            return _movieContext.Categories.FirstOrDefault(i => i.CategoryId == id);
        }

        public async Task<Category> DeleteCategory(int id)
        {
            var deleted = Id(id);
            if (deleted != null)
            {
                _movieContext.Categories.Remove(deleted);
                await SaveChangeMethodAsync();
                return deleted;
            }
            return null;
        }
        public async Task<Category> EditCategory(UpdateCategory category)
        {
            var result = await _movieContext.Categories
                .Include(m => m.Movies)
                .FirstOrDefaultAsync(i => i.CategoryId == category.CategoryId);
            if (result != null)
            {
                result.Name = category.CategoryName;
                await SaveChangeMethodAsync();
                return result;
            }
            return null;
        }

        public IQueryable<Category> GetCategories()
        {
            return _movieContext.Categories.AsQueryable();
        }
        public void SaveChanges()
        {
              _movieContext.SaveChanges();
        }
        private async Task SaveChangeMethodAsync()
        {
            await _movieContext.SaveChangesAsync();
        }
    }
}
