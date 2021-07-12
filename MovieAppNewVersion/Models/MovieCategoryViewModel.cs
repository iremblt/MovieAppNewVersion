using MovieAppNewVersion.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Models
{
    public class MovieCategoryViewModel
    {
        public List<MovieViewMode> Movies { get; set; }
    }
    public class MovieViewMode
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string MovieImage { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
    }
    public class CategoryViewModel
    {
        public string CategoryName { get; set; }
    }
}
