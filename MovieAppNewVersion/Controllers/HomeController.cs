using Microsoft.AspNetCore.Mvc;
using MovieAppNewVersion.Business.Abstract;

namespace MovieAppNewVersion.Controllers
{
    public class HomeController:Controller
    {
        private readonly IMovieService _movieService;
        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            var movies = _movieService.GetAllMoviesIncludeCategories();
            return View(movies);
        }
    }
}
