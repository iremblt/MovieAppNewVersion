using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieAppNewVersion.Business.Abstract;
using MovieAppNewVersion.Controllers;
using Xunit;
using static MovieAppNewVersion.DTO.DTOs.MovieCategoryDTO.MovieCategoryViewModelDTO;

namespace MovieAppNewVersion.Test
{
    
    public class ApiControllerTests
    {

        [Fact]
        public void GetById_GetByMovieId_ReturnsOkResult()
        {
            var mocks = new Mock<IMovieService>();
            var controller = new ApiController(mocks.Object);
            var actual = controller.GetById(2);
            Assert.IsType<OkObjectResult>(actual);
        }
        [Fact]
        public void GetById_GetByMovieId_ReturnsRightResult()
        {
            var expected = new MovieViewModel { MovieId = 1, MovieAbout = "new", MovieDescription = "smot", MovieImage = "1.png", MovieTitle = "Harry Potter" };
            var mock = new Mock<IMovieService>();
            mock.Setup(i => i.GetMovieWithMapping(1))
                .Returns(expected);
            var controller = new ApiController(mock.Object);
            var result = controller.GetById(1);
            var model = Assert.IsType<OkObjectResult>(result);
            var actual = Assert.IsType<MovieViewModel>(model.Value);
            Assert.Equal(expected.MovieId,actual.MovieId);
        }
    }
}
