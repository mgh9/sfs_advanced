namespace SFSAdv.Application.Products.Models;

public sealed record AddProductDto(string Title, int InventoryCount, decimal Price, double Discount);
