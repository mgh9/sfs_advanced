using FluentValidation;

namespace SFSAdv.Application.Products.Commands.AddProduct;

public class CreateCustomerCommandValidator : AbstractValidator<AddProductCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Title)
            .MaximumLength(40);

        RuleFor(x => x.Price)
            .NotEmpty();
    }
}
