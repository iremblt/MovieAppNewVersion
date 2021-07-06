using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieAppNewVersion.Data;
using MovieAppNewVersion.Entity;
using MovieAppNewVersion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext _movieContext;
        public MoviesController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public IActionResult List(int? id,string q)
        {
            
            //  var movies = MovieRepository.Movies;
             var movies = _movieContext.Movies.AsQueryable();
          //  var movies = _movieContext.Movies.ToList();
            if (id != null)
            {
                movies = movies
                    .Include(i=>i.Categories)
                    .Where(i => i.Categories.Any(c=>c.CategoryId==id));
            }

            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(
                    i => i.MovieTitle.ToLower().Contains(q.ToLower())|| 
                    i.MovieDescription.ToLower().Contains(q.ToLower())||
                    i.MovieAbout.ToLower().Contains(q.ToLower()));
            }
            var viewmodel = new MovieViewModel()
            {
                Movies = movies.ToList()
            };
            return View(viewmodel);
        }
        public IActionResult Details(int id)
        {
            //   var movieId = MovieRepository.GetById(id);
            //   return View(_movieContext.Movies.FirstOrDefault(i=>i.MovieId==id));
            return View(_movieContext.Movies.Find(id));
        }
        [HttpGet]
        public IActionResult Create()
        {
            //  ViewBag.Category = new SelectList(CategoryRepository.Categories, "CategoryId", "Name");
            ViewBag.Category = new SelectList(_movieContext.Categories.ToList(),"CategoryId","Name");
            ViewBag.Votes = VoteRepository.Votes.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                // MovieRepository.AddMovie(movie);
                _movieContext.Movies.Add(movie);
                _movieContext.SaveChanges();
                TempData["message"] = $"{movie.MovieTitle} added";
                return RedirectToAction("List");
            }
        //    ViewBag.Votes = new SelectList(VoteRepository.Votes.ToList(), "VoteId", "VoteName");
            //  ViewBag.Category = new SelectList(CategoryRepository.Categories,"CategoryId","Name");
            ViewBag.Category = new SelectList(_movieContext.Categories.ToList(), "CategoryId", "Name");
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // ViewBag.Category = new SelectList(CategoryRepository.Categories, "CategoryId", "Name");
            ViewBag.Category = new SelectList(_movieContext.Categories.ToList(), "CategoryId", "Name");
            //   return View(MovieRepository.GetById(id));
            return View(_movieContext.Movies.Find(id));
        }
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                //MovieRepository.EditMovie(movie);
                    _movieContext.Movies.Update(movie);
                    _movieContext.SaveChanges();
                    TempData["message"] = $"{movie.MovieTitle} editted";
                    return RedirectToAction("Details","Movies",new { @id=movie.MovieId});               
            }
            // ViewBag.Category = new SelectList(CategoryRepository.Categories, "CategoryId", "Name");
            ViewBag.Category = new SelectList(_movieContext.Categories.ToList(), "CategoryId", "Name");
            return View(movie);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            //  return View(MovieRepository.GetById(id));
            return View(_movieContext.Movies.Find(id));
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            //  MovieRepository.DeleteMovie(id);
            var movies = _movieContext.Movies.Find(id);
            _movieContext.Movies.Remove(movies);
            _movieContext.SaveChanges();
             TempData["message"]= $"{id} is deleted";
             return RedirectToAction("List");
        }
    }
}
