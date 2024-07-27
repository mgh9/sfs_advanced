using AutoMapper;
using SFSAdv.Application.Abstractions.Queries;
using SFSAdv.Domain.Aggregates.UserAggregate;
using SFSAdv.Domain.Aggregates.UserAggregate.ReadModels;

namespace SFSAdv.Application.Users.Queries.GetUsers;

public sealed class GetUsersQueryHandler : QueryHandler<GetUsersQuery, IReadOnlyCollection<UserReadModel>>
{
    private readonly IUserRepository _userRepository;

    public GetUsersQueryHandler(IMapper mapper, IUserRepository userRepository)
        : base(mapper)
    {
        _userRepository = userRepository;
    }

    protected async override Task<IReadOnlyCollection<UserReadModel>> HandleAsync(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAsync(cancellationToken: cancellationToken);
        return Mapper.Map<List<UserReadModel>>(users);
    }
}
