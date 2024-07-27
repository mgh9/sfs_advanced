using SFSAdv.Application.Abstractions.Exceptions;

namespace SFSAdv.Application.Exceptions;

public class CustomApplicationValidationException : BaseApplicationException
{
    public IReadOnlyDictionary<string, string[]> Errors { get; set; }

    public CustomApplicationValidationException(IReadOnlyDictionary<string, string[]> errors)
        : base("One or more validation errors occurred")
    {
        Errors = errors;
    }
}
