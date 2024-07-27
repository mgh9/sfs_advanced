using SFSAdv.Application.Abstractions.Commands;

namespace SFSAdv.Application.Products.Commands.AddProduct;

public record BuyProductCommand(Guid BuyerUserId, Guid ProductId) : Command<Guid>;
