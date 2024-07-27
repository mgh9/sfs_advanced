using MediatR;

namespace SFSAdv.Application.Abstractions.Queries;

public abstract record Query<T> : IRequest<T>;
