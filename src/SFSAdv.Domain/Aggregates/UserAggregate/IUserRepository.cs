using SFSAdv.Domain.Abstractions.Persistence;
using SFSAdv.Domain.Aggregates.UserAggregate.Entities;

namespace SFSAdv.Domain.Aggregates.UserAggregate;

public interface IUserRepository : IRepository<User>
{

}