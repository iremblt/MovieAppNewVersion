using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAppNewVersion.Business.Abstract;
using MovieAppNewVersion.DTO.DTOs.CategoryDTO;
using MovieAppNewVersion.DTO.DTOs.MovieDTO;
using MovieAppNewVersion.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public AdminController(IMovieService movieService, ICategoryService categoryService,IMapper mapper)
        {
            _movieService = movieService;
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public IActionResult MovieList()
        {
            var movies = _mapper.Map<List<MovieListDTO>>(_movieService.GetMoviesWithCategories());
            return View(movies);
        }
        public IActionResult CategoryList()
        {
            var categories = _mapper.Map<List<CategoryListDTO>>(_categoryService.GetAll().Include(i => i.Movies));
            return View(categories);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var updated = _mapper.Map<MovieUpdateDTO>(_movieService.GetMovieByCategory(id));
            ViewBag.Categories = _mapper.Map<List<CategoryListDTO>>(_categoryService.GetAll());
            if (updated == null)
            {
                return NotFound();
            }
            return View(updated);
        }
        [HttpPost] 
        public async Task<IActionResult> Update(MovieUpdateDTO model, int[] categoryId)
        {
            if (ModelState.IsValid) 
            {
                var updated = _mapper.Map<MovieUpdateDTO, Movie>(model);
                await _movieService.Update(updated);
                var category = _mapper.Map<Movie>(_movieService.GetMovieByCategory(updated.MovieId));
                category.Categories = categoryId.Select(i => _categoryService.GetById(i)).ToList();
                await _movieService.Update(category);
                return RedirectToAction("MovieList");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        { 
            var result = _mapper.Map<MovieDeleteDTO>(_movieService.GetById(id));
            if (result != null)
            {
                return View(result);
            }
            return NotFound();
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(MovieDeleteDTO movie)
        {
            var deleted = _mapper.Map<MovieDeleteDTO, Movie>(movie);
            await _movieService.Delete(deleted.MovieId);
            return RedirectToAction("MovieList");
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = _mapper.Map<List<CategoryListDTO>>(_categoryService.GetAll());
            return View(new MovieAddDTO());
        }
        [HttpPost]
        public IActionResult Add(MovieAddDTO model, int[] categoryId)
        {

            if (ModelState.IsValid)
            {
                model.Categories = new List<Category>();
                foreach (var id in categoryId)
                {
                    model.Categories.Add(_categoryService.GetCategoryByMovie(id));
                }
                var movie = _mapper.Map<MovieAddDTO,Movie>(model);
                _movieService.Add(movie);
                return RedirectToAction("MovieList", "Admin");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult<Category> CategoryUpdate(int id)
        {
            var result = _mapper.Map<CategoryUpdateDTO>(_categoryService.GetCategoryByMovie(id));
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> CategoryUpdate(CategoryUpdateDTO updateCategory, int movieId)
        {
            if (ModelState.IsValid) 
            {
                var updated = _mapper.Map<CategoryUpdateDTO, Category>(updateCategory);
                await _categoryService.Update(updated);
                var result = _mapper.Map<Category>(_categoryService.GetCategoryByMovie(updated.CategoryId));
                var deletedMovie = result.Movies.FirstOrDefault(m => m.MovieId == movieId);
                result.Movies.Remove(deletedMovie);
                _categoryService.Save();
                return RedirectToAction("CategoryList");
            }
            return View(updateCategory);

        }
        [HttpGet]
        public IActionResult CategoryDelete(int id)
        {
            var result = _mapper.Map<CategoryDeleteDTO>(_categoryService.GetById(id));
            if (result != null)
            {
                return View(result);
            }
            return NotFound();
        }
        [HttpPost, ActionName("CategoryDelete")]
        public async Task<IActionResult> CategoryDeleteConfirmed(CategoryDeleteDTO category)
        {
            var deleted=_mapper.Map<CategoryDeleteDTO, Category>(category);
            await _categoryService.Delete(deleted.CategoryId);
            return RedirectToAction("CategoryList");
        }
    }
}
