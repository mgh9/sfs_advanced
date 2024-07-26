namespace SFSAdv.Domain.Abstractions.Exceptions;

public class NotFoundException : DomainException
{
    public NotFoundException()
        : this("Not found")
    {

    }

    public NotFoundException(string message)
        : base(message)
    {

    }
}
