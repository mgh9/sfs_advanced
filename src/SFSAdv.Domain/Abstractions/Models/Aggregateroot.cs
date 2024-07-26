namespace SFSAdv.Domain.Abstractions.Models;

public abstract class AggregateRoot
{
    public Guid Id { get; protected set; }

    // Optionally include a collection for domain events
    private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

    // Optional: Add domain events to be handled later
    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    // Optional: Retrieve all domain events
    public IReadOnlyCollection<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.AsReadOnly();
    }

    // Optional: Clear domain events after handling
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}