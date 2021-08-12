using Moq;
using MovieAppNewVersion.Business.Abstract;
using Xunit;
using MovieAppNewVersion.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static MovieAppNewVersion.DTO.DTOs.MovieCategoryDTO.MovieCategoryViewModelDTO;

namespace MovieAppNewVersion.Test
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_AllMoviesIncludeCategories_ReturnsOkResult()
        {
            var movies = new List<MovieViewModel>();
            movies.Add(new MovieViewModel()
            {
                MovieAbout = "new",
                MovieDescription = "details",
                MovieId = 1,
                MovieImage = "1.png",
                MovieTitle = "Hello"
            });
            movies.Add(new MovieViewModel()
            {
                MovieAbout = "news",
                MovieDescription = "detail",
                MovieId = 2,
                MovieImage = "2.png",
                MovieTitle = "Hi"
            });
            var mocks = new Mock<IMovieService>();
            mocks.Setup(r => r.GetAllMoviesIncludeCategories()).Returns(movies);
            var controller = new HomeController(mocks.Object);
            var result = controller.Index();
            Assert.IsType<ViewResult>(result);
        }
    }
}
