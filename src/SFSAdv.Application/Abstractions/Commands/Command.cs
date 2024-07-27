using MediatR;

namespace SFSAdv.Application.Abstractions.Commands;

public abstract record Command : IRequest;
public abstract record Command<TResponse> : IRequest<TResponse>;
