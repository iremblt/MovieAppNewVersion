using MovieAppNewVersion.Entities.Concrete;
using System.Collections.Generic;

namespace MovieAppNewVersion.DTO.DTOs.MovieDTO
{
    public class MovieListDTO
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string MovieImage { get; set; }
        public string MovieAbout { get; set; }
        public string MovieDescription { get; set; }
        public List<Category> Categories { get; set; }

    }
}
