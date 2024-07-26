using SFSAdv.Domain.Abstractions.Exceptions;
using SFSAdv.Domain.Aggregates.OrderAggregate.Entities;
using SFSAdv.Domain.Utilities;

namespace SFSAdv.Domain.Aggregates.UserAggregate;

public partial class User
{
    public void AddOrder(Order order)
    {
        Guard.AgainstNull(order, nameof(order));

        if (Orders.Contains(order))
            throw new DomainException("Order already associated with this user.");

        Orders.Add(order);
    }
}
