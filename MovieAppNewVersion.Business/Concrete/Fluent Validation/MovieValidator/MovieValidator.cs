using FluentValidation;
using MovieAppNewVersion.Entities.Concrete;

namespace MovieAppNewVersion.Business.Concrete.Fluent_Validation.MovieValidator
{
    public class MovieValidator:AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(x => x.MovieTitle).NotEmpty().WithMessage("Title is required").MaximumLength(50).WithMessage("Title should have maximum 50 length");
            RuleFor(x => x.MovieAbout).NotEmpty().WithMessage("About is required");
        }
    }
}
