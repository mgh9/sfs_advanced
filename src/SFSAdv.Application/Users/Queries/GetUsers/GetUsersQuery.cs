using SFSAdv.Application.Abstractions.Queries;
using SFSAdv.Domain.Aggregates.UserAggregate.ReadModels;

namespace SFSAdv.Application.Users.Queries.GetUsers;

public sealed record GetUsersQuery() : Query<IReadOnlyCollection<UserReadModel>>;
