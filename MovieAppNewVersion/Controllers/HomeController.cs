using Microsoft.AspNetCore.Mvc;
using MovieAppNewVersion.Data;
using MovieAppNewVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Controllers
{
    public class HomeController:Controller
    {
        private readonly MovieContext _movieContext;
        public HomeController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public IActionResult Index()
        {
            //var movies = MovieRepository.Movies;
            var movies = _movieContext.Movies.ToList();
            var model = new HomePageViewModel()
            {
                PopulerMovies = movies
            };
        return View(model);
        }
    }
}
