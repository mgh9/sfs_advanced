using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SFSAdv.Domain.Abstractions.Models;
using SFSAdv.Domain.Abstractions.Persistence;

namespace SFSAdv.Infrastructure.Persistence.Repositories;

public abstract class BaseRepository<TEntity> : IRepository<TEntity>
    where TEntity : AggregateRoot
{
    private readonly AppDbContext _context;
    protected readonly DbSet<TEntity> DbSet;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
        DbSet = _context.Set<TEntity>();
    }

    public async Task<IReadOnlyCollection<TEntity>> GetAsync(CancellationToken cancellationToken = default)
    {
        return (await DbSet
                        .AsNoTracking()
                        .ToListAsync(cancellationToken: cancellationToken)).AsReadOnly();
    }

    public async Task<IReadOnlyCollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>> criteria, CancellationToken cancellationToken = default)
    {
        return (await DbSet
                        .AsNoTracking()
                        .Where(criteria)
                        .ToListAsync(cancellationToken: cancellationToken)).AsReadOnly();
    }

    public async Task<TEntity?> GetAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        return await DbSet.FindAsync([Id], cancellationToken: cancellationToken);
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await DbSet.AddAsync(entity, cancellationToken);
    }

    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        DbSet.Remove(entity);
    }
}