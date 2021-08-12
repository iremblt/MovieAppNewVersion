using AutoMapper;
using Microsoft.AspNetCore.Http;
using MovieAppNewVersion.Business.Abstract;
using MovieAppNewVersion.DataAccess.Abstract;
using MovieAppNewVersion.DTO.DTOs.CategoryDTO;
using MovieAppNewVersion.DTO.DTOs.MovieCategoryDTO;
using MovieAppNewVersion.DTO.DTOs.MovieDTO;
using MovieAppNewVersion.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MovieAppNewVersion.DTO.DTOs.MovieCategoryDTO.MovieCategoryViewModelDTO;

namespace MovieAppNewVersion.Business.Concrete
{
    public class MovieManager : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public MovieManager(IMovieRepository movieRepository,IMapper mapper,ICategoryService categoryService)
        {
            _movieRepository = movieRepository;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public Movie GetMovieIncludeCategory(int id)
        {
            return  _movieRepository.GetMovieIncludeCategory(id);
        }

        public IQueryable<Movie> GetMoviesWithCategories()
        {
            return _movieRepository.GetMoviesWithCategories();
        }
        public List<MovieViewModel> GetAllMoviesIncludeCategories() 
        {
            return _mapper.Map<List<MovieViewModel>>(_movieRepository.GetMoviesWithCategories());
        }
        public IQueryable<MovieViewModel> Search(MovieSearchDTO movieSearch)
        {
            var search = GetAllMoviesIncludeCategories().AsQueryable();
            search = search.Where(i => i.MovieAbout.Contains(movieSearch.Search.ToLower())         
            || i.MovieDescription.Contains(movieSearch.Search.ToLower())
            || i.MovieTitle.Contains(movieSearch.Search.ToLower()));
            return search;
        }

        public Movie AddCategoryToMovie(Movie movie, int[] categoryId)
        {
            return _movieRepository.AddCategoryToMovie(movie, categoryId);
        }
        public async Task<string> CreateAMovie(MoviesAndCategoriesListsForCreate movie, int[] categoryId,IFormFile file)
        {
            var added =_mapper.Map<MovieAddDTO, Movie>(movie.movieAdd);
            var adding = _movieRepository.AddCategoryToMovie(added, categoryId);
            if (file != null)
            {
                adding = _movieRepository.AddImageFileToMovie(file, added);
            }
            string message = await _movieRepository.Create(adding);
            return message;
        }
        public async Task<string> EditAMovie(MoviesAndCategoriesListsForEdit movie, int[] categoryId,IFormFile file)
        {
            var updated = _mapper.Map<MovieUpdateDTO, Movie>(movie.movieUpdate, _movieRepository.GetMovieIncludeCategory(movie.movieUpdate.MovieId));
            var update=_movieRepository.AddCategoryToMovie(updated, categoryId);
            if (file != null)
            {
                update = _movieRepository.AddImageFileToMovie(file, updated);
            }
            string message = await _movieRepository.Update(update);
            return message;
        }
        public MovieViewModel GetMovieWithMapping(int id) 
        {
            return _mapper.Map<MovieViewModel>(_movieRepository.GetMovieIncludeCategory(id));
        }
        public async Task<MovieViewModel> CreateMovie(MovieAddDTO movieAdd, IFormFile file)
        {
            var added = _mapper.Map<MovieAddDTO, Movie>(movieAdd);
            if (file != null)
            {
                added = _movieRepository.AddImageFileToMovie(file, added);
            }
            await _movieRepository.Create(added);
            return GetMovieWithMapping(added.MovieId);
        }
        public async Task<MovieViewModel> EditMovie(MovieUpdateDTO movieUpdate, IFormFile file)
        {
            var updated = _mapper.Map<MovieUpdateDTO, Movie>(movieUpdate);
            if (file != null)
            {
                updated = _movieRepository.AddImageFileToMovie(file, updated);
            }
            await _movieRepository.Update(updated);
            return GetMovieWithMapping(updated.MovieId);
        }
        public async Task<string> DeleteMovie(int id) 
        {
            return await _movieRepository.Delete(id);
        }
        public MovieListDTO GetByMovieIdWithCategory(int id)
        {
            return _mapper.Map<MovieListDTO>(_movieRepository.GetMovieIncludeCategory(id));
        }
        public MovieUpdateDTO GetByMovieIdWithUpdateDTO(int id)
        {
            return _mapper.Map<MovieUpdateDTO>(_movieRepository.GetMovieIncludeCategory(id));
        }
        public Movie AddImageFileToMovie(IFormFile file, Movie movie)
        {
            return _movieRepository.AddImageFileToMovie(file, movie);
        }
        public MoviesAndCategoriesListsForCreate GetCategoriesForCreateView(MoviesAndCategoriesListsForCreate movie,int [] categoryId)
        {
            MoviesAndCategoriesListsForCreate moviesAndCategories = new MoviesAndCategoriesListsForCreate();
            moviesAndCategories.CategoryList = _categoryService.GetAllCategories();
            moviesAndCategories.movieAdd = movie.movieAdd;
            moviesAndCategories.SelectedCategories = new List<CategoryListDTO>();
            foreach (var category in categoryId)
            {
                moviesAndCategories.SelectedCategories.Add(_categoryService.GetByCategoryId(category));
            }
            return moviesAndCategories;
        }
        public MoviesAndCategoriesListsForEdit GetCategoriesForEditView(MoviesAndCategoriesListsForEdit movie, int[] categoryId)
        {
            MoviesAndCategoriesListsForEdit moviesAndCategories = new MoviesAndCategoriesListsForEdit();
            moviesAndCategories.CategoriesList = _categoryService.GetAllCategories();
            moviesAndCategories.movieUpdate = movie.movieUpdate;
            moviesAndCategories.Categories = new List<CategoryListDTO>();
            foreach (var category in categoryId)
            {
                moviesAndCategories.Categories.Add(_categoryService.GetByCategoryId(category));
            }
            return moviesAndCategories;
        }
    }
}