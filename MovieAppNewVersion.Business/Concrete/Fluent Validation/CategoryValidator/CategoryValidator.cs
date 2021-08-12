using FluentValidation;
using MovieAppNewVersion.Entities.Concrete;

namespace MovieAppNewVersion.Business.Concrete.Fluent_Validation.CategoryValidator
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").MinimumLength(3).WithMessage("Category name has should minimum three lengths.");
        }
    }
}
