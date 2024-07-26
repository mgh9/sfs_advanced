using SFSAdv.Domain.Abstractions.Persistence;

namespace SFSAdv.Domain.Aggregates.ProductAggregate.Entities;

public interface IProductRepository : IRepository<Product>
{
    Task<Product?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);
}