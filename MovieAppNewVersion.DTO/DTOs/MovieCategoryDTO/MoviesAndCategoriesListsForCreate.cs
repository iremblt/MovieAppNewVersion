using MovieAppNewVersion.DTO.DTOs.CategoryDTO;
using MovieAppNewVersion.DTO.DTOs.MovieDTO;
using System.Collections.Generic;

namespace MovieAppNewVersion.DTO.DTOs.MovieCategoryDTO
{
    public class MoviesAndCategoriesListsForCreate
    {
        public MovieAddDTO movieAdd { get; set; }
        public List<CategoryListDTO> CategoryList { get; set; }
        public List<CategoryListDTO> SelectedCategories { get; set; }
    }
}
