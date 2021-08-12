using FluentValidation;
using MovieAppNewVersion.DTO.DTOs.CategoryDTO;

namespace MovieAppNewVersion.Business.Concrete.Fluent_Validation.CategoryValidator
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDTO>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").MinimumLength(3).WithMessage("Category name has should minimum three lengths.");
        }
    }
}