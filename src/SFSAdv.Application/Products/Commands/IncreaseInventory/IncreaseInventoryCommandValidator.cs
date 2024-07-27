using FluentValidation;

namespace SFSAdv.Application.Products.Commands.IncreaseInventory;

public class IncreaseInventoryCommandValidator : AbstractValidator<IncreaseInventoryCommand>
{
    public IncreaseInventoryCommandValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty();
    }
}
