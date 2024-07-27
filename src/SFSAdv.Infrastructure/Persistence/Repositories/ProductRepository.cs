using Microsoft.EntityFrameworkCore;
using SFSAdv.Domain.Aggregates.ProductAggregate.Entities;

namespace SFSAdv.Infrastructure.Persistence.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context)
        : base(context)
    {
    }

    public async Task<Product?> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(p => p.Title == title, cancellationToken);
    }
}