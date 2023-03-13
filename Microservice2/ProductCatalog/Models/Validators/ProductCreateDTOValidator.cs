using FluentValidation;
using ProductCatalog.Models.Params;

namespace ProductCatalog.Models.Validators;

public class ProductCreateDTOValidator : AbstractValidator<ProductCreateParam>
{
    public ProductCreateDTOValidator()
    {
        RuleFor(x => x.Name)
        .MaximumLength(100)
        .NotEmpty();

        RuleFor(x => x.Description)
        .MaximumLength(100)
        .NotEmpty();

        RuleFor(x => x.Price)
        .NotNull();

        RuleFor(x => x.Quantity)
        .NotNull();

        RuleFor(x => x.ImageUrl)
        .NotEmpty()
        .ValidateUri();
    }
}