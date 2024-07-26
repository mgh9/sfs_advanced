using SFSAdv.Domain.Abstractions.Models;

namespace SFSAdv.Domain.Aggregates.ProductAggregate.Events;

public record ProductInventoryChangedEvent(Guid ProductId, int NewInventoryCount) : IDomainEvent
{
    public DateTime OccurredOn => DateTime.Now;
}
