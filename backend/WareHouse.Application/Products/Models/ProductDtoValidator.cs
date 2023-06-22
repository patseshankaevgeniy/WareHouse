using FluentValidation;

namespace WareHouse.Application.Products.Models;

public class ProductDtoValidator : AbstractValidator<ProductModel>
{
    public ProductDtoValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
}
