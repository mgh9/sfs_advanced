using SFSAdv.Domain.Abstractions.Persistence;
using SFSAdv.Domain.Aggregates.OrderAggregate;
using SFSAdv.Domain.Aggregates.OrderAggregate.Entities;

namespace SFSAdv.Infrastructure.Persistence.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
    {
    }
}