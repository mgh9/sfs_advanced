namespace SFSAdv.Domain.Abstractions.Models;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}