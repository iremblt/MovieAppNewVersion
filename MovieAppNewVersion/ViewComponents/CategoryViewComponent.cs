using Microsoft.AspNetCore.Mvc;
using MovieAppNewVersion.Data;
using MovieAppNewVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.ViewComponents
{
    public class CategoryViewComponent:ViewComponent
    {
        private readonly MovieContext _movieContext;
        public CategoryViewComponent(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData.Values["id"];
            //  return View(CategoryRepository.Categories);
            return View(_movieContext.Categories.ToList());
        }
    }
}
