using MovieAppNewVersion.Entities.Concrete;
using System.Collections.Generic;

namespace MovieAppNewVersion.DTO.DTOs.CategoryDTO
{
   public class CategoryUpdateDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
