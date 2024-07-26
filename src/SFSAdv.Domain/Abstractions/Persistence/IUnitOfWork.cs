using Microsoft.EntityFrameworkCore;

namespace SFSAdv.Domain.Abstractions.Persistence;

public interface IUnitOfWork
{
    DbContext Context { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
