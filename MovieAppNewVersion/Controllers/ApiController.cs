using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MovieAppNewVersion.Business.Abstract;
using MovieAppNewVersion.DTO.DTOs.MovieDTO;
using System.Threading.Tasks;
namespace MovieAppNewVersion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : Controller
    {
        private readonly IMovieService _movieService;
        public ApiController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet("GetMovies")]
        public IActionResult GetMovies()
        {
            var model = _movieService.GetAllMoviesIncludeCategories();
            return Ok(model);
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var movie= _movieService.GetMovieWithMapping(id);
            if (movie != null)
            {
                return Ok(movie);
            }
            return Ok("The movie did not found");
        }
        [HttpPost("AddMovie")]
        public async Task<IActionResult> AddMovie(MovieAddDTO movie, IFormFile file)
        {
            if (ModelState.IsValid) 
            {
                var model = await _movieService.CreateMovie(movie,file);
                return Ok("Movie");
            }
            return Ok("The movie couldn't added.");
        }

        [HttpDelete("DeleteMovie/{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var deleted = await _movieService.DeleteMovie(id);
            return Ok(deleted);

        }
        [HttpPut("UpdateMovie/{id}")] //Postman de gözükmyor
        public async Task<IActionResult> UpdateMovie(int id, MovieUpdateDTO update, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                update.MovieId = id;
                var model = await _movieService.EditMovie(update,file);
                return Ok(model);
            }
            return Ok("The movie did not update");
        }
    }
}
