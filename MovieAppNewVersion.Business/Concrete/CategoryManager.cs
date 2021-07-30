using MovieAppNewVersion.Business.Abstract;
using MovieAppNewVersion.DataAccess.Abstract;
using MovieAppNewVersion.Entities.Concrete;
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
        public async Task<Category> Add(Category t)
        {
            return await _categoryRepository.Add(t);
        }

        public async Task<Category> Delete(int id)
        {
            return await _categoryRepository.Delete(id);
        }

        public IQueryable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public Category GetCategoryByMovie(int id)
        {
            return _categoryRepository.GetCategoryByMovie(id);
        }

        public void Save()
        {
            _categoryRepository.Save();
        }

        public async Task<Category> Update(Category t)
        {
            return await _categoryRepository.Update(t);
        }
    }
}
