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
        private readonly MovieContext _movieContext;
        public ApiController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetMovies")]
        public async Task<IActionResult> GetMovies()
        {
            var list = _movieContext.Movies.AsQueryable();
            var model = new MovieCategoryViewModel()
            {
                Movies = list
                .Select(i => new MovieViewMode
                {

                    MovieId = i.MovieId,
                    MovieImage = i.MovieImage,
                    MovieAbout = i.MovieAbout,
                    MovieDescription = i.MovieDescription,
                    MovieTitle = i.MovieTitle,
                    Categories = i.Categories.Select(c => new CategoryViewModel
                    {
                        CategoryName = c.Name
                    }).ToList()
                }).ToList()
            };
            return Ok(model);
        }
        [HttpGet("GetOnlyThirdMovie")]
        public async Task<IActionResult> GetOnlyThirdMovie()
        {
            //GetOnlyThirdMovive(3);
            var id = 3;
            //var movie = _movieContext.Movies.Find(id);
            var movie = _movieContext.Movies.FirstOrDefault(i => i.MovieId == id);
            return Ok(movie);
        }
        [HttpGet("GetById/{id}")]
       // [Route("{action}/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
           var movie = _movieContext.Movies.FirstOrDefault(i => i.MovieId == id);
           if (movie != null)
            {
                return Ok(movie);  
            }
            return Ok("The movie did not found");
        }
        [HttpPost("AddMovie")]
        public async Task<IActionResult> AddMovie(AddMovie movie)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Movies.Add(new Movie()
                {
                    MovieAbout = movie.MovieAbout,
                    MovieDescription = movie.MovieDescription,
                    MovieImage = movie.MovieImage,
                    MovieTitle = movie.MovieTitle,
                    Categories = movie.Categories.Select(c => new Category
                    {
                        Name = c.Name
                    }).ToList()
                });
                _movieContext.SaveChanges();
                return Ok(movie);
            }
            return Ok("It couldnt add");
        }

        [HttpDelete("DeleteMovie/{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var deletedmovie =_movieContext.Movies.FirstOrDefault(m => m.MovieId == id);
            if (deletedmovie == null)
            {
                return BadRequest("There is no movie in this id");
            }
            _movieContext.Remove(deletedmovie);
            _movieContext.SaveChanges();
            return Ok(deletedmovie);
        }
        [HttpPut("UpdateMovie/{id}")]
        public async Task<IActionResult> UpdateMovie(int id,UpdateMovie update)
        {
            var updatedModel = _movieContext.Movies.FirstOrDefault(m=>m.MovieId==id);
            if (updatedModel == null)
                return BadRequest();


            updatedModel.MovieAbout = update.MovieAbout;
            updatedModel.MovieDescription = update.MovieDescription;
            updatedModel.MovieImage = update.MovieImage;
            updatedModel.MovieTitle = update.MovieTitle;
            updatedModel.Categories = update.Categories;
            _movieContext.SaveChanges();
            return Ok(updatedModel);
        }


        //[HttpPost("AddMovie")]
        //public async Task<IActionResult>AddMovie(Movie movie)
        //{
        //    var m = _movieContext.Movies.Add(movie);
        //    _movieContext.SaveChanges();
        //   // return Ok(m);
        //   return CreatedAtAction(nameof(GetById),new { id=movie.MovieId},movie);
        //}
        //[HttpDelete("DeleteMovie/{id}")]
        //public async Task<IActionResult> DeleteMovie(int id)
        //{
        //    var movie = _movieContext.Movies.Find(id);
        //    if (movie != null)
        //    {
        //        _movieContext.Movies.Remove(movie);
        //        _movieContext.SaveChanges();
        //        return Ok("Movie is deleted");
        //    }
        //    return Ok("There is no movie in this id.");
        //}
    }
}
