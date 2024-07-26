using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SFSAdv.Domain.Abstractions.Models;
using SFSAdv.Domain.Abstractions.Persistence;

namespace SFSAdv.Infrastructure.Persistence.Repositories;

public abstract class BaseRepository<TEntity> : IRepository<TEntity>
    where TEntity : AggregateRoot
{
    private readonly IUnitOfWork _unitOfWork;
    protected readonly DbSet<TEntity> DbSet;

    public BaseRepository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        DbSet = _unitOfWork.Context.Set<TEntity>();
    }

    public async Task<TEntity?> GetAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        return await DbSet.FindAsync([Id], cancellationToken: cancellationToken);
    }

    public async Task<IReadOnlyCollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>> criteria, CancellationToken cancellationToken = default)
    {
        return await DbSet
                        .AsNoTracking()
                        .Where(criteria)
                        .ToListAsync(cancellationToken: cancellationToken);
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