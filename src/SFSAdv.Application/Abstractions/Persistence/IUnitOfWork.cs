namespace SFSAdv.Application.Abstractions.Persistence;

public interface IUnitOfWork
{
    //DbContext Context { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
