namespace SFSAdv.Application.Abstractions.Exceptions;

public class ApplicationValidationException : BaseApplicationException
{
    public IReadOnlyDictionary<string, string[]> Errors { get; set; }

    public ApplicationValidationException(IReadOnlyDictionary<string, string[]> errors)
        : base("One or more validation errors occurred")
    {
        Errors = errors;
    }
}
