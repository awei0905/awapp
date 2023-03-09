using FluentValidation;
using ProductCatalog.Models.Params;

namespace ProductCatalog.Models.Validators;

public class ProductUpdateDTOValidator : AbstractValidator<ProductUpdateParam>{
    public ProductUpdateDTOValidator() {
        
    }
}