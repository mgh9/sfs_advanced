using SFSAdv.Domain.Aggregates.OrderAggregate.ReadModels;

namespace SFSAdv.Domain.Aggregates.UserAggregate.ReadModels;

public class UserReadModel
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public IEnumerable<OrderReadModel> Orders { get; set; } = new List<OrderReadModel>();
}
