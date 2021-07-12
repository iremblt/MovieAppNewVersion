using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class AdminController : Controller
    {
        private IMovieRepository _movieRepository;
        private ICategoryRepository _categoryRepository;
        public AdminController(IMovieRepository movieRepository, ICategoryRepository categoryRepository)
        {
            _movieRepository = movieRepository;
            _categoryRepository = categoryRepository;
        }
        public IActionResult MovieList()
        {
            var movies = _movieRepository.GetAll()
               .Include(i=>i.Categories);
            return View(movies);
        }
        public IActionResult CategoryList()
        {
            var categories = _categoryRepository.GetCategories()
                .Include(i => i.Movies);
            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var updated = await _movieRepository.GetById(id);
            ViewBag.Categories = _categoryRepository.GetCategories().ToList();
            if (updated == null)
            {
                return NotFound();
            }
            return View(updated);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateMovie model, int[] categoryId)
        {
            model.Categories = categoryId.Select(i => _categoryRepository.Id(i)).ToList();
            await _movieRepository.EditMovie(model);
            return RedirectToAction("MovieList");
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
            return RedirectToAction("MovieList");
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = _categoryRepository.GetCategories().ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddMovie model,int [] categoryId)
        {
            model.Categories = new List<Category>();
            foreach (var id in categoryId)
            {
                model.Categories.Add(_categoryRepository.Id(id));
            }
            _movieRepository.AddMovie(model);
             return RedirectToAction("MovieList","Admin");
        }
        [HttpGet]
        public ActionResult<Category> CategoryUpdate(int id)
        {
            var result = _categoryRepository.Id(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> CategoryUpdate(UpdateCategory updateCategory,int movieId)
        {
            await _categoryRepository.EditCategory(updateCategory);
            var updated =  _categoryRepository.Id(updateCategory.CategoryId);
            var deletedMovie = updated.Movies.FirstOrDefault(m => m.MovieId == movieId);
            updated.Movies.Remove(deletedMovie);
            _categoryRepository.SaveChanges();
           return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public async Task<IActionResult> CategoryDelete(int id)
        {
            var result =  _categoryRepository.Id(id);
            if (result != null)
            {
                return View(result);
            }
            return NotFound();
        }
        [HttpPost, ActionName("CategoryDelete")]
        public async Task<IActionResult> CategoryDeleteConfirmed(int id)
        {
            await _categoryRepository.DeleteCategory(id);
            return RedirectToAction("CategoryList");
        }
    }
}
