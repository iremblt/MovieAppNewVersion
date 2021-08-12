using AutoMapper;
using MovieAppNewVersion.Business.Abstract;
using MovieAppNewVersion.DataAccess.Abstract;
using MovieAppNewVersion.DTO.DTOs.CategoryDTO;
using MovieAppNewVersion.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryManager(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public Category GetByIdCategoryIncludeMovie(int id)
        {
            return _categoryRepository.GetByIdCategoryIncludeMovie(id);
        }

        public List<Category> GetCategoriesIncludeMovie()
        {
            return _categoryRepository.GetCategoriesIncludeMovies();
        }

        public List<CategoryListDTO> GetAllCategories()
        {
            return _mapper.Map<List<CategoryListDTO>>(_categoryRepository.GetCategoriesIncludeMovies());
        }
        public CategoryListAndCreateDTO GetAllCategoriesIncludeMovies()
        {
            CategoryListAndCreateDTO categoryList = new CategoryListAndCreateDTO();
            categoryList.CategoryLists = GetAllCategories();
            categoryList.CategoryAdd = new CategoryAddDTO();
            return categoryList;
        }

        public async Task<string> CreateCategory(CategoryAddDTO c)
        {
            var categoryAdd= _mapper.Map<CategoryAddDTO, Category>(c);
            return await _categoryRepository.Create(categoryAdd);
        }

        public async Task<string> UpdateCategory(CategoryUpdateDTO c)
        {
            var categoryupdate = _mapper.Map<CategoryUpdateDTO, Category>(c);
            return await _categoryRepository.Update(categoryupdate);
        }

        public CategoryListDTO GetByCategoryId(int id)
        {
            return _mapper.Map<CategoryListDTO>(_categoryRepository.GetByIdCategoryIncludeMovie(id));
        }
        public async Task<string> DeleteCategory(int id) 
        {
            return await _categoryRepository.Delete(id);
        }
    }
}