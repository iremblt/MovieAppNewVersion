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
        private IMovieRepository _movieRepository;
        public HomeController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public IActionResult Index()
        {
            var movies = _movieRepository.GetAll();
            return View(movies);
        }
    }
}
