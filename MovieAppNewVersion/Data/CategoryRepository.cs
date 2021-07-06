using MovieAppNewVersion.Entity;
using MovieAppNewVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Data
{
    public static class CategoryRepository
    {
        private static readonly List<Category> _categories = null;
        static CategoryRepository()
        {
            _categories = new List<Category>()
            {
                new Category(){Name="Action"},
                new Category(){Name="Advanture"},
                new Category(){Name="Comedy"},
                new Category(){Name="Crime"},
                new Category(){Name="Drama"},
                new Category(){Name="Mystery"},
                new Category(){Name="Romance"},
                new Category(){Name="Sci-Fi"},
                new Category(){Name="Thriller"}
            };
        }
        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }
        public static void Add(Category category)
        {
            _categories.Add(category);
        }
        public static Category GetById(int id)
        {
            return _categories.FirstOrDefault(i => i.CategoryId == id);
        }
    }
}
