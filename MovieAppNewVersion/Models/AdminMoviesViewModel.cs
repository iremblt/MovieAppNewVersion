using MovieAppNewVersion.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Models
{
    public class AdminMoviesViewModel
    {
        public List<AdminMovieModel> Movies { get; set; }
    }
    public class AdminMovieModel
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string MovieImage { get; set; }
        public List<CategoryMovieModel> Categories { get; set; }
    }
    public class CategoryMovieModel
    {
        public string Name { get; set; }
    }
    public class UpdateMovieModel
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string MovieImage { get; set; }
        public string Description { get; set; }
        public string About { get; set; }
        public List<Category> SelectedCategories { get; set; }
    }
    public class DeleteMovieModel
    {
        public int MovieId { get; set; }
    }
    public class AddMovieModel
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string MovieImage { get; set; }
        public string Description { get; set; }
        public string About { get; set; }
    }
}
