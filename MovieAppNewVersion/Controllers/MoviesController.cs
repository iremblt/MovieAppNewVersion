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
        private IMovieRepository _movieRepository;
        private ICategoryRepository _categoryRepository;
        public MoviesController(IMovieRepository movieRepository,ICategoryRepository categoryRepository)
        {
            _movieRepository = movieRepository;
            _categoryRepository = categoryRepository;
    }
        public IActionResult List(int? id,string q)
        {
            var movies = _movieRepository.GetAll();
            if (id != null)
            {
                movies = movies
                   .Include(i => i.Categories)
                   .Where(i => i.Categories.Any(c=>c.CategoryId==id));
            }

            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(
                    i => i.MovieTitle.ToLower().Contains(q.ToLower())|| 
                    i.MovieDescription.ToLower().Contains(q.ToLower())||
                    i.MovieAbout.ToLower().Contains(q.ToLower()));
            }
            var viewmodel = movies.ToList();
            return View(viewmodel);
        }
        public async Task<IActionResult> Details(int id)
        {
            var details = await _movieRepository.GetById(id);
            return View(details);
        }
        [HttpGet]
        public ActionResult<Movie> Create()
        {
            ViewBagCategoryMethod();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddMovie movie,int [] categoryId)
        {
            if (ModelState.IsValid)
            {
                movie.Categories = new List<Category>();
                foreach (var id in categoryId)
                {
                     movie.Categories.Add(_categoryRepository.Id(id));
                }
                await _movieRepository.AddMovie(movie);
                TempData["message"] = $"{movie.MovieTitle} added";
                return RedirectToAction("List");
            }
            ViewBagCategoryMethod();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var updated = await _movieRepository.GetById(id);
            ViewBagCategoryMethod();
            if (updated == null)
            {
                return NotFound();
            }
            return View(updated);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateMovie model,int [] categoryId)
        {
            if (ModelState.IsValid)
            {
                model.Categories = categoryId.Select(i => _categoryRepository.Id(i)).ToList();
                await _movieRepository.EditMovie(model);
                TempData["message"] = $"{model.MovieTitle} editted";
                return RedirectToAction("List");
            }
            ViewBagCategoryMethod();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _movieRepository.GetById(id);
            if (result != null)
            {
                return View(result);
            }
            return NotFound();
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _movieRepository.DeleteMovie(id);
            TempData["message"]= $"{id} is deleted";
            return RedirectToAction("List");
        }
        private void ViewBagCategoryMethod()
        {
            ViewBag.Categories = _categoryRepository.GetCategories().ToList();
        }
    }
}
