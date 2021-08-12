using System.Collections.Generic;

namespace MovieAppNewVersion.DTO.DTOs.CategoryDTO
{
    public class CategoryListAndCreateDTO
    {
        public List<CategoryListDTO> CategoryLists { get; set; }
        public CategoryAddDTO CategoryAdd{ get; set; }
    }
}
