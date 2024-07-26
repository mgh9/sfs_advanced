namespace SFSAdv.Domain.Aggregates.OrderAggregate.ReadModels;

public record OrderReadModel(Guid Id, Guid ProductId, Guid BuyerId, DateTime CreationDate);
