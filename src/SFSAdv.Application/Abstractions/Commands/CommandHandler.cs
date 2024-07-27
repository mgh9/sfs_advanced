using SFSAdv.Application.Abstractions.Persistence;

namespace SFSAdv.Application.Abstractions.Commands;

public abstract class CommandHandler
{
    protected readonly IUnitOfWork UnitOfWork;

    protected CommandHandler(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
}

