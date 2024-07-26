namespace SFSAdv.Domain.Aggregates.ProductAggregate.Events;

public record ProductPriceChangedEvent(Guid ProductId, decimal OldPrice, decimal NewPrice);
