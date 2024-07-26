namespace SFSAdv.Domain.Aggregates.ProductAggregate.Events;

public record ProductCreatedEvent(
                    Guid ProductId,
                    string Title,
                    int InventoryCount,
                    decimal Price,
                    double Discount);