using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using MovieAppNewVersion.Business.Abstract;
using System.Collections.Generic;
using MovieAppNewVersion.Entities.Concrete;
using MovieAppNewVersion.DTO.DTOs.MovieDTO;
using AutoMapper;
using MovieAppNewVersion.DTO.DTOs.CategoryDTO;

namespace MovieAppNewVersion.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public MoviesController(IMovieService movieService, ICategoryService categoryService,IMapper mapper)
        {
            _movieService = movieService;
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public IActionResult List(string q)
        {
            var movies = _mapper.Map<List<MovieListDTO>>(_movieService.GetMoviesWithCategories());
            if (!string.IsNullOrEmpty(q)) 
            {
                movies = _mapper.Map<List<MovieListDTO>>(_movieService.Search(q));
            }
            return View(movies);
        }
        public ActionResult<Movie> Details(int id)
        {
            var details = _mapper.Map<MovieListDTO>(_movieService.GetMovieByCategory(id));
            return View(details);
        }
        [HttpGet]
        public ActionResult<Movie> Create()
        {
            ViewBagCategoryMethod();
            return View(new MovieAddDTO());
        }
        [HttpPost]
        public async Task<IActionResult> Create(MovieAddDTO movie, int[] categoryId)
        {
            if (ModelState.IsValid)
            {
                movie.Categories = new List<Category>();
                foreach (var id in categoryId)
                {
                    movie.Categories.Add(_categoryService.GetCategoryByMovie(id));
                }
                var added = _mapper.Map<MovieAddDTO, Movie>(movie);
                await _movieService.Add(added);
                TempData["message"] = $"{movie.MovieTitle} added";
                return RedirectToAction("List");
            }
            ViewBagCategoryMethod();
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        { 
            var updated = _mapper.Map<MovieUpdateDTO>(_movieService.GetMovieByCategory(id));
            ViewBagCategoryMethod();
            if (updated == null)
            {
                return NotFound();
            }
            return View(updated);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MovieUpdateDTO model, int[] categoryId)
        {
            if (ModelState.IsValid)
            {
                var updated = _mapper.Map<MovieUpdateDTO, Movie>(model);
                await _movieService.Update(updated);
                var category = _mapper.Map<Movie>(_movieService.GetMovieByCategory(updated.MovieId));
                category.Categories = categoryId.Select(i => _categoryService.GetById(i)).ToList();
                await _movieService.Update(category);
                TempData["message"] = $"{model.MovieTitle} editted";
                return RedirectToAction("List");
            }
            ViewBagCategoryMethod();
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
            TempData["message"] = $"{movie.MovieId} is deleted";
            return RedirectToAction("List");
        }
        private void ViewBagCategoryMethod()
        {
            ViewBag.Categories = _mapper.Map<List<CategoryListDTO>>(_categoryService.GetAll());
        }
    }
}
