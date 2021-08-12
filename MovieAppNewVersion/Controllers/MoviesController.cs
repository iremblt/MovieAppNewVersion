using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MovieAppNewVersion.Business.Abstract;
using MovieAppNewVersion.Entities.Concrete;
using MovieAppNewVersion.DTO.DTOs.MovieDTO;
using MovieAppNewVersion.DTO.DTOs.MovieCategoryDTO;
using MovieAppNewVersion.Business.Concrete.Fluent_Validation;
using MovieAppNewVersion.DTO.DTOs.CategoryDTO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;

namespace MovieAppNewVersion.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICategoryService _categoryService;
        public MoviesController(IMovieService movieService, ICategoryService categoryService)
        {
            _movieService = movieService;
            _categoryService = categoryService;
        }
        public IActionResult List(MovieSearchDTO searchDTO) 
        {
            if (searchDTO.Search!=null)
            {
                var search = _movieService.Search(searchDTO);
                return View(search);
            }
            else
            {
            var movies = _movieService.GetAllMoviesIncludeCategories();
            return View(movies);
            }

        }
        public ActionResult<Movie> Details(int id)
        {
            var details = _movieService.GetByMovieIdWithCategory(id);
            return View(details);
        }
        [HttpGet]
        public ActionResult<Movie> Create()
        {
            MoviesAndCategoriesListsForCreate moviesAndCategories = new MoviesAndCategoriesListsForCreate();
            moviesAndCategories.CategoryList = _categoryService.GetAllCategories();
            return View(moviesAndCategories);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (MoviesAndCategoriesListsForCreate Add,int [] categoryId, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string message= await _movieService.CreateAMovie(Add, categoryId,file);
                TempData["message"] = message;
                return RedirectToAction("List");
            }
            var moviesAndCategories= _movieService.GetCategoriesForCreateView(Add, categoryId);
            return View(moviesAndCategories);
        }
        [HttpGet]
        public IActionResult Edit (int id)
        {
            MoviesAndCategoriesListsForEdit moviesAndCategories = new MoviesAndCategoriesListsForEdit();
            moviesAndCategories.CategoriesList = _categoryService.GetAllCategories();
            var updated = _movieService.GetByMovieIdWithUpdateDTO(id);
            moviesAndCategories.movieUpdate = updated;
            moviesAndCategories.Categories = updated.Categories;
            if (updated == null)
            {
                return NotFound();
            }
            return View(moviesAndCategories);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MoviesAndCategoriesListsForEdit update, IFormFile file,int [] categoryId)
        {
            if (ModelState.IsValid)
            {
                string message = await _movieService.EditAMovie(update,categoryId,file);
                TempData["message"] = message;
                return RedirectToAction("List");
            }
            var moviesAndCategories = _movieService.GetCategoriesForEditView(update, categoryId);
            return View(moviesAndCategories);
        }
        [HttpGet]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _movieService.GetByMovieIdWithCategory(id);
            if (result != null)
            {
                return View(result);
            }
            return NotFound();
        }
        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> Delete(MovieDeleteDTO movie)
        {
            var message= await _movieService.DeleteMovie(movie.MovieId);
            TempData["message"] = message;
            return RedirectToAction("List");
        }
    }
}
