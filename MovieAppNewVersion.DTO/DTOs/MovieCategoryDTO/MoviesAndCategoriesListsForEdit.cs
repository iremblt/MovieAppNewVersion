using MovieAppNewVersion.DTO.DTOs.CategoryDTO;
using MovieAppNewVersion.DTO.DTOs.MovieDTO;
using System.Collections.Generic;

namespace MovieAppNewVersion.DTO.DTOs.MovieCategoryDTO
{
    public class MoviesAndCategoriesListsForEdit
    {
        public MovieUpdateDTO movieUpdate { get; set; }
        public List<CategoryListDTO> CategoriesList { get; set; }
        public List<CategoryListDTO> Categories { get; set; }
    }
}
