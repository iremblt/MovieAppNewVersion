using Microsoft.AspNetCore.Http;
using MovieAppNewVersion.DTO.DTOs.MovieCategoryDTO;
using MovieAppNewVersion.DTO.DTOs.MovieDTO;
using MovieAppNewVersion.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MovieAppNewVersion.DTO.DTOs.MovieCategoryDTO.MovieCategoryViewModelDTO;

namespace MovieAppNewVersion.Business.Abstract
{
    public interface IMovieService
    {
        Movie GetMovieIncludeCategory(int id);
        IQueryable<Movie> GetMoviesWithCategories();
        List<MovieViewModel> GetAllMoviesIncludeCategories();
        IQueryable<MovieViewModel> Search(MovieSearchDTO movieSearch);
        Movie AddCategoryToMovie(Movie movie, int[] categoryId);
        Task<string> EditAMovie(MoviesAndCategoriesListsForEdit movie, int[] categoryId,IFormFile file);
        Task<string> CreateAMovie(MoviesAndCategoriesListsForCreate movie, int[] categoryId, IFormFile file);
        MovieViewModel GetMovieWithMapping(int id);
        Task<MovieViewModel> CreateMovie(MovieAddDTO movieAdd, IFormFile file);
        Task<MovieViewModel> EditMovie(MovieUpdateDTO movieUpdate, IFormFile file);
        Task<string> DeleteMovie(int id);
        MovieListDTO GetByMovieIdWithCategory(int id);
        MovieUpdateDTO GetByMovieIdWithUpdateDTO(int id);
        Movie AddImageFileToMovie(IFormFile file, Movie movie);
        MoviesAndCategoriesListsForCreate GetCategoriesForCreateView(MoviesAndCategoriesListsForCreate movie, int[] categoryId);
        MoviesAndCategoriesListsForEdit GetCategoriesForEditView(MoviesAndCategoriesListsForEdit movie, int[] categoryId);
    }
}
