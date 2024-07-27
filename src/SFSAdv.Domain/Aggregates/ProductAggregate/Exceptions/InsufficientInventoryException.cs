using SFSAdv.Domain.Abstractions.Exceptions;

namespace SFSAdv.Domain.Aggregates.ProductAggregate.Exceptions;

public class InsufficientInventoryException : DomainException
{
    public InsufficientInventoryException(string message)
        : base(message)
    {
    }

    public InsufficientInventoryException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

