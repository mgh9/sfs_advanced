using SFSAdv.Application.Abstractions.Commands;

namespace SFSAdv.Application.Products.Commands.AddProduct;

public record AddProductCommand(string Title, int InventoryCount, decimal Price, double Discount) : Command<Guid>;
