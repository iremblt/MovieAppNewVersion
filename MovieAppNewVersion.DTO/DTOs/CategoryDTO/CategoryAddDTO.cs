using MovieAppNewVersion.DTO.DTOs.MovieDTO;
using System.Collections.Generic;

namespace MovieAppNewVersion.DTO.DTOs.CategoryDTO
{
   public class CategoryAddDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<MovieListDTO> Movies { get; set; }
    }
}
