using FluentValidation;
using MovieAppNewVersion.DTO.DTOs.MovieCategoryDTO;
using MovieAppNewVersion.DTO.DTOs.MovieDTO;

namespace MovieAppNewVersion.Business.Concrete.Fluent_Validation.MovieValidator
{
    public class MovieUpdateValidator:AbstractValidator<MoviesAndCategoriesListsForEdit>
    {
        public MovieUpdateValidator()
        {
            RuleFor(x => x.movieUpdate.MovieTitle).NotEmpty().WithMessage("Title is required").MaximumLength(50).WithMessage("Title should have maximum 50 length");
            RuleFor(x => x.movieUpdate.MovieAbout).NotEmpty().WithMessage("About is required");
            RuleFor(x => x.movieUpdate.MovieDescription).NotEmpty().WithMessage("Description is required");
            //RuleFor(x => x.movieUpdate.MovieImage).NotEmpty().WithMessage("Image is required");
        }
    }
}
