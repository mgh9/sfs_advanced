using FluentValidation;
using MediatR;
using SFSAdv.Application.Abstractions.Exceptions;

namespace SFSAdv.Application.Behaviors;

public class CustomValidationBehaviors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public CustomValidationBehaviors(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var errorsDictionary = _validators
                                    .Select(x => x.Validate(context))
                                    .SelectMany(x => x.Errors)
                                    .Where(x => x is not null)
                                    .GroupBy(
                                            x => x.PropertyName.Substring(x.PropertyName.IndexOf('.') + 1),
                                            x => x.ErrorMessage, (propertyName, errorMessage) =>
                                                                new
                                                                {
                                                                    Key = propertyName,
                                                                    Values = errorMessage.Distinct().ToArray()
                                                                })
                                    .ToDictionary(x => x.Key, x => x.Values);

        if (errorsDictionary.Count != 0)
        {
            throw new ApplicationValidationException(errorsDictionary);
        }

        return await next();
    }
}