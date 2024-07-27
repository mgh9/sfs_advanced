using System.Linq.Expressions;
using SFSAdv.Domain.Abstractions.Models;

namespace SFSAdv.Domain.Abstractions.Persistence;

public interface IRepository<TEntity> 
    where TEntity : AggregateRoot
{
    Task<IReadOnlyCollection<TEntity>> GetAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>> criteria, CancellationToken cancellationToken = default);
    Task<TEntity?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}