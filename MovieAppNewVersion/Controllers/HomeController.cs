using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieAppNewVersion.Business.Abstract;
using MovieAppNewVersion.DTO.DTOs.MovieDTO;
using System.Collections.Generic;

namespace MovieAppNewVersion.Controllers
{
    public class HomeController:Controller
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;
        public HomeController(IMovieService movieService,IMapper mapper )
        {
            _movieService = movieService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var movies = _mapper.Map<List<MovieListDTO>>(_movieService.GetMoviesWithCategories());
            return View(movies);
        }
    }
}
