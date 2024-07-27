namespace SFSAdv.Domain.Abstractions.Exceptions;

public class DomainValidationException : DomainException
{
    public DomainValidationException(string message)
        : base(message)
    {
    }

    public DomainValidationException(string message , string paramName)
        : base(message)
    {
        ParamName = paramName;
    }

    public DomainValidationException(string message, Exception inner)
        : base(message, inner)
    {
    }

    public DomainValidationException(string message,string paramName, Exception inner)
        : base(message, inner)
    {
        ParamName = paramName;
    }

    public string? ParamName { get; } = null;
}

