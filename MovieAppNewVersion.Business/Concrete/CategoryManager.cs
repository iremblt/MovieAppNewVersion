using MovieAppNewVersion.Business.Abstract;
using MovieAppNewVersion.DataAccess.Abstract;
using MovieAppNewVersion.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<string> Create(Category t)
        {
            return await _categoryRepository.Create(t);
        }

        public async Task<string> Delete(int id)
        {
            return await _categoryRepository.Delete(id);
        }

        public IQueryable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int ?id)
        {
            return _categoryRepository.GetById(id);
        }

        public Category GetByIdCategoryIncludeMovie(int id)
        {
            return _categoryRepository.GetByIdCategoryIncludeMovie(id);
        }

        public void Save()
        {
            _categoryRepository.Save();
        }

        public async Task<string> Update(Category t)
        {
            return await _categoryRepository.Update(t);
        }

        public List<Category> GetCategoriesIncludeMovie()
        {
            return _categoryRepository.GetCategoriesIncludeMovies();
        }

        public string IsMethodSuccess(int n)
        {
            return _categoryRepository.IsMethodSuccess(n);
        }
    }
}
