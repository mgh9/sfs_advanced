using FluentValidation;
using SFSAdv.Application.Products.Commands.AddProduct;

namespace SFSAdv.Application.Orders.Commands.BuyProduct;

public class BuyProductCommandValidator : AbstractValidator<BuyProductCommand>
{
    public BuyProductCommandValidator()
    {
        RuleFor(x => x.BuyerUserId)
            .NotEmpty();

        RuleFor(x => x.ProductId)
            .NotEmpty();
    }
}
