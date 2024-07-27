using SFSAdv.Domain.Aggregates.OrderAggregate;
using SFSAdv.Domain.Aggregates.OrderAggregate.Entities;

namespace SFSAdv.Infrastructure.Persistence.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context)
        : base(context)
    {
    }
}