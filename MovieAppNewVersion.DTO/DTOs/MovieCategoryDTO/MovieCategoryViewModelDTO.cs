using System.Collections.Generic;

namespace MovieAppNewVersion.DTO.DTOs.MovieCategoryDTO
{
    public class MovieCategoryViewModelDTO
    {
        public class MovieViewModel
        {
            public int MovieId { get; set; }
            public string MovieTitle { get; set; }
            public string MovieImage { get; set; }
            public string MovieAbout { get; set; }
            public string MovieDescription { get; set; }
            public List<CategoryViewModel> Categories { get; set; }
        }
        public class CategoryViewModel
        {
            public string Name { get; set; }
        }
    }
}
