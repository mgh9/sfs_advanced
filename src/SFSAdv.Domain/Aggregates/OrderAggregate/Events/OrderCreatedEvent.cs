using SFSAdv.Domain.Abstractions.Models;

namespace SFSAdv.Domain.Aggregates.OrderAggregate.Events;

public record OrderCreatedEvent (Guid OrderId, Guid ProductId, Guid BuyerId, decimal Price, double Discount, DateTime CreationDate)
    : IDomainEvent
{
    public DateTime OccurredOn => CreationDate;
}
