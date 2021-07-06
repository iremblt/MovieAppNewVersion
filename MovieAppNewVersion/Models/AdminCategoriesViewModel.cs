using MovieAppNewVersion.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Models
{
    public class AdminCategoriesViewModel
    {
        public List<AdminCategoryViewModel> Categories { get; set; }
    }
    public class AdminCategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Count { get; set; }
    }
    public class UpdateCategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<AdminMovieModel> AdminMovieModels { get; set; }
    }
    public class DeleteCategoryModel
    {
        public int CategoryId { get; set; }
    }
}
