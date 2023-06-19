using FluentValidation;

namespace WareHouse.Application.Products.Models;

public class ProductDtoValidator : AbstractValidator<ProductDto>
{
    public ProductDtoValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
}
