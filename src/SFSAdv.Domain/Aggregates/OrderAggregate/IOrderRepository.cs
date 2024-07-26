using SFSAdv.Domain.Abstractions.Persistence;
using SFSAdv.Domain.Aggregates.OrderAggregate.Entities;

namespace SFSAdv.Domain.Aggregates.OrderAggregate;

public interface IOrderRepository : IRepository<Order>
{

}