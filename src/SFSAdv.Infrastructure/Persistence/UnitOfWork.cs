using Microsoft.EntityFrameworkCore;
using SFSAdv.Application.Abstractions.Persistence;
using SFSAdv.Domain.Abstractions.Persistence;

namespace SFSAdv.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    //public DbContext Context => _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}