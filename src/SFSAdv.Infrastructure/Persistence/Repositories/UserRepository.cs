using SFSAdv.Domain.Abstractions.Persistence;
using SFSAdv.Domain.Aggregates.UserAggregate;
using SFSAdv.Domain.Aggregates.UserAggregate.Entities;

namespace SFSAdv.Infrastructure.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(IUnitOfWork unitOfWork)
        : base(unitOfWork)
    {
    }
}