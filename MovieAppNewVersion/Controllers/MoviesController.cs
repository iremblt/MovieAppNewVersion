using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MovieAppNewVersion.Business.Abstract;
using MovieAppNewVersion.Entities.Concrete;
using MovieAppNewVersion.DTO.DTOs.MovieDTO;
using AutoMapper;
using System.Collections.Generic;
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
            var details = _mapper.Map<MovieListDTO>(_movieService.GetMovieIncludeCategory(id));
            return View(details);
        }
        [HttpGet]
        public ActionResult<Movie> Create()
        {
            GetAllCategories();
            return View(new MovieAddDTO());
        }
        [HttpPost]
        public async Task<IActionResult> Create(MovieAddDTO movieAdd, int[] categoryId)
        {
            if (ModelState.IsValid)
            {
                var adding = _mapper.Map<MovieAddDTO, Movie>(movieAdd);
                string message= await _movieService.CreateAMovie(adding,categoryId);
                TempData["message"] = message;
                return RedirectToAction("List");
            }
            GetAllCategories();
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var updated = _mapper.Map<MovieUpdateDTO>(_movieService.GetMovieIncludeCategory(id));
            GetAllCategories();
            if (updated == null)
            {
                return NotFound();
            }
            return View(updated);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MovieUpdateDTO movieUpdate,int [] categoryId)
        {
            if (ModelState.IsValid)
            {
                var updating = _mapper.Map<MovieUpdateDTO, Movie>(movieUpdate, _movieService.GetMovieIncludeCategory(movieUpdate.MovieId));
                string message = await _movieService.EditAMovie(updating,categoryId);
                TempData["message"] = message;
                return RedirectToAction("List");
            }
            GetAllCategories();
            return View(movieUpdate);
        }
        [HttpGet]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _movieService.GetById(id);
            if (result != null)
            {
                return View(result);
            }
            return NotFound();
        }
        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> Delete(MovieDeleteDTO movie)
        {
            var message= await _movieService.Delete(movie.MovieId);
            TempData["message"] = message;
            return RedirectToAction("List");
        }
        private void GetAllCategories()
        {
            ViewBag.Categories = _mapper.Map<List<CategoryListDTO>>(_categoryService.GetAll());
        }
    }
}
