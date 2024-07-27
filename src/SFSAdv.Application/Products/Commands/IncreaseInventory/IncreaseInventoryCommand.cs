using SFSAdv.Application.Abstractions.Commands;

namespace SFSAdv.Application.Products.Commands.IncreaseInventory;

public record IncreaseInventoryCommand(Guid ProductId, int Amount) : Command;
