using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MovieAppNewVersion.Business.Abstract;
using MovieAppNewVersion.DTO.DTOs.MovieDTO;
using MovieAppNewVersion.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;
using static MovieAppNewVersion.DTO.DTOs.MovieCategoryDTO.MovieCategoryViewModelDTO;

namespace MovieAppNewVersion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;
        public ApiController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }
        [HttpGet("GetMovies")]
        public IActionResult GetMovies()
        {
            var model = _mapper.Map<List<MovieViewModel>>(_movieService.GetMoviesWithCategories());
            return Ok(model);
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
            {
            var movie = _mapper.Map<MovieViewModel>(_movieService.GetMovieByCategory(id));
            if (movie != null)
            {
                return Ok(movie);
            }
            return Ok("The movie did not found");
        }
        [HttpPost("AddMovie")]
        public async Task<IActionResult> AddMovie(MovieAddDTO movie)
        {
            if (ModelState.IsValid) 
            {
                var added = _mapper.Map<MovieAddDTO, Movie>(movie);
                await _movieService.Add(added);
                var model = _mapper.Map<MovieViewModel>(_movieService.GetMovieByCategory(added.MovieId));
                return Ok(model);
            }
            return Ok("The movie couldn't added.");
        }

        [HttpDelete("DeleteMovie/{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var delete = _mapper.Map<MovieDeleteDTO>(_movieService.GetById(id));
            var deleted = await _movieService.Delete(delete.MovieId);
            return Ok(deleted);
        }
        [HttpPut("UpdateMovie/{id}")]
        public async Task<IActionResult> UpdateMovie(int id, MovieUpdateDTO update)
        {
            if (ModelState.IsValid) 
            { 
                update.MovieId = id;
                var updated = _mapper.Map<MovieUpdateDTO, Movie>(update);
                await _movieService.Update(updated);
                var model = _mapper.Map<MovieViewModel>(_movieService.GetMovieByCategory(updated.MovieId));
                return Ok(model);
            }
            return Ok("The movie did not update");
        }
    }
}
