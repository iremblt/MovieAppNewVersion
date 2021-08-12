using FluentValidation;
using MovieAppNewVersion.DTO.DTOs.MovieCategoryDTO;
using MovieAppNewVersion.DTO.DTOs.MovieDTO;

namespace MovieAppNewVersion.Business.Concrete.Fluent_Validation.MovieValidator
{
    public class MovieAddValidator : AbstractValidator<MoviesAndCategoriesListsForCreate>
    {
        public MovieAddValidator()
        {
            RuleFor(x => x.movieAdd.MovieTitle).NotEmpty().WithMessage("Title is required")
                .MaximumLength(50).WithMessage("Title should have maximum 50 length");
            RuleFor(x => x.movieAdd.MovieDescription).NotEmpty().WithMessage("Description is required");
        }
    }
}