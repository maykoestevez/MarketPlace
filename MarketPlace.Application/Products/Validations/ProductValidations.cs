using FluentValidation;
using MarketPlace.Application.Product.Validations;

namespace MarketPlace.Application.Products.Validations;

public sealed class CreateProductValidations : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidations()
    {
        RuleFor(s => s.Name).NotEmpty().NotNull();
    }
}

public sealed class UpdateProductValidations : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductValidations()
    {
        RuleFor(s => s.Name).NotEmpty().NotNull();
    }
}

public sealed class DeleteProductValidations : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductValidations()
    {
        RuleFor(s => s.Id).NotEmpty().NotNull();
    }
}