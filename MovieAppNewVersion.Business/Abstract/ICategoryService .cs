using MovieAppNewVersion.DTO.DTOs.CategoryDTO;
using MovieAppNewVersion.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Business.Abstract
{
    public interface ICategoryService
    {
        Category GetById(int id);
        Category GetByIdCategoryIncludeMovie(int id);
        List<Category> GetCategoriesIncludeMovie();
        List<CategoryListDTO> GetAllCategories();
        Task<string> CreateCategory(CategoryAddDTO c);
        Task<string> UpdateCategory(CategoryUpdateDTO c);
        Task<string> DeleteCategory(int id);
        CategoryListDTO GetByCategoryId(int id);
        CategoryListAndCreateDTO GetAllCategoriesIncludeMovies();
    }
}