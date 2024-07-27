using MediatR;
using SFSAdv.Application.Abstractions.Persistence;

namespace SFSAdv.Application.Abstractions.Commands;

public abstract class CommandHandler<TCommand> : CommandHandler, IRequestHandler<TCommand>
    where TCommand : Command
{
    protected CommandHandler(IUnitOfWork unitOfWork)
        : base(unitOfWork)
    { }

    public async Task Handle(TCommand request, CancellationToken cancellationToken = default)
    {
        await HandleAsync(request, cancellationToken);
    }

    protected abstract Task HandleAsync(TCommand request, CancellationToken cancellationToken);
}

public abstract class CommandHandler<TCommand, TResponse> : CommandHandler, IRequestHandler<TCommand, TResponse>
    where TCommand : Command<TResponse>
{
    protected CommandHandler(IUnitOfWork unitOfWork)
        : base(unitOfWork)
    { }

    public async Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken = default)
    {
        return await HandleAsync(request, cancellationToken);
    }

    protected abstract Task<TResponse> HandleAsync(TCommand request, CancellationToken cancellationToken);
}
