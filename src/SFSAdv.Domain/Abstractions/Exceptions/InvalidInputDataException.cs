namespace SFSAdv.Domain.Abstractions.Exceptions;

public class InvalidInputDataException : DomainException
{
    public InvalidInputDataException(string message)
        : base(message)
    {
    }

    public InvalidInputDataException(string message , string paramName)
        : base(message)
    {
        ParamName = paramName;
    }

    public InvalidInputDataException(string message, Exception inner)
        : base(message, inner)
    {
    }

    public InvalidInputDataException(string message,string paramName, Exception inner)
        : base(message, inner)
    {
        ParamName = paramName;
    }

    public string? ParamName { get; } = null;
}

