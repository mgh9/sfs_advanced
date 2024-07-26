using SFSAdv.Domain.Abstractions.Models;
using SFSAdv.Domain.Aggregates.OrderAggregate.Entities;

namespace SFSAdv.Domain.Aggregates.UserAggregate.Entities;

public partial class User : AggregateRoot
{
    public string Name { get; private set; } = "";
    public List<Order> Orders { get; private set; } = [];
}
