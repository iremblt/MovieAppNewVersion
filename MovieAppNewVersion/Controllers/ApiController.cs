using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MovieAppNewVersion.Data;
using MovieAppNewVersion.Entity;
using MovieAppNewVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : Controller
    {
        private IMovieRepository _movieRepository;
        public ApiController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        [HttpGet("GetMovies")]
        public async Task<IActionResult> GetMovies()
        {
            var list = _movieRepository.GetAll();
            var model = new MovieCategoryViewModel
            {
                 Movies = list
                .Select(i=> new MovieViewMode 
                { 
                    MovieId=i.MovieId,
                    MovieImage=i.MovieImage,
                    MovieTitle=i.MovieTitle,
                    Categories=i.Categories.Select(i=>new CategoryViewModel
                    { 
                        CategoryName=i.Name
                    }).ToList()
                })
                .ToList()
            };
            return Ok(model);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie =  await _movieRepository.GetById(id);
            if (movie != null)
            {
                var model = new MovieViewMode
                {
                    MovieImage = movie.MovieImage,
                    MovieTitle = movie.MovieTitle,
                    MovieId = movie.MovieId,
                    Categories = movie.Categories.Select(i => new CategoryViewModel { CategoryName = i.Name }).ToList()
                };
                return Ok(model);
            }
            return Ok("The movie did not found");
        }
        [HttpPost("AddMovie")]
        public async Task<IActionResult> AddMovie(AddMovie movie)
        {
            await _movieRepository.AddMovie(movie);
            var model = new MovieViewMode
            {
                MovieImage = movie.MovieImage,
                MovieTitle = movie.MovieTitle,
                MovieId = movie.MovieId,
                Categories = movie.Categories.Select(i => new CategoryViewModel { CategoryName = i.Name }).ToList()
            };
            return Ok(model);
        }

        [HttpDelete("DeleteMovie/{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(int id)
        {
            var deleted = await _movieRepository.DeleteMovie(id);
            return Ok(deleted);
        }
        [HttpPut("UpdateMovie/{id}")]
        public async Task<IActionResult> UpdateMovie(int id, UpdateMovie update)
        {
            update.MovieId = id;
            await _movieRepository.UpdateMovie(update);
            var model = new MovieViewMode
            {
                MovieImage = update.MovieImage,
                MovieTitle = update.MovieTitle,
                MovieId = update.MovieId,
                Categories = update.Categories.Select(i => new CategoryViewModel { CategoryName = i.Name }).ToList()
            };
            return Ok(model);
        }
    }
}
