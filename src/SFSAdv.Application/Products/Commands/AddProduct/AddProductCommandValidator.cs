using FluentValidation;

namespace SFSAdv.Application.Products.Commands.AddProduct;

public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
{
    public AddProductCommandValidator()
    {
        RuleFor(x => x.Title)
            .MaximumLength(40);

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.Discount)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.InventoryCount)
            .GreaterThanOrEqualTo(0);
    }
}
