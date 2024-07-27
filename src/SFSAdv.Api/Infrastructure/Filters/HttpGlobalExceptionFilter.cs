using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;
using SFSAdv.Api.Infrastructure.ActionResults;
using SFSAdv.Application.Exceptions;
using SFSAdv.Domain.Abstractions.Exceptions;

namespace SFSAdv.Api.Infrastructure.Filters;

public sealed class HttpGlobalExceptionFilter : IExceptionFilter
{
    private readonly IWebHostEnvironment _env;
    private readonly ILogger<HttpGlobalExceptionFilter> _logger;

    public HttpGlobalExceptionFilter(IWebHostEnvironment env, ILogger<HttpGlobalExceptionFilter> logger)
    {
        _env = env;
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        Envelope envelope;
        switch (context.Exception)
        {
            case NotFoundException notFoundException:
                envelope = Envelope.Create(notFoundException.Message, HttpStatusCode.NotFound);
                break;

            case UnauthorizedAccessException unauthorizedAccessException:
                envelope = Envelope.Create(unauthorizedAccessException.Message, HttpStatusCode.Forbidden);
                //envelope = Envelope.Create("Access Denied", HttpStatusCode.Unauthorized);
                break;

            case CustomApplicationValidationException validationException:
                envelope = CreateValidationErrorEnvelope(validationException);
                break;

            case DomainException domainException:
                envelope = Envelope.Create(domainException.Message, HttpStatusCode.BadRequest);
                break;

            default:
                string message = FetchExceptionMessage(context);
                envelope = Envelope.Create(message, HttpStatusCode.InternalServerError);
                break;
        }

        _logger.LogError(new EventId(context.Exception.HResult),
                        context.Exception,
                        message: "{message}", envelope.ErrorMessage);

        context.Result = envelope.ToActionResult();
        context.HttpContext.Response.StatusCode = envelope.Status;
        context.ExceptionHandled = true;
    }

    private string FetchExceptionMessage(ExceptionContext context)
    {
        return _env.IsDevelopment()
            ? context.Exception.ToString()
            : "Sorry an error occurred.";
    }

    private static Envelope CreateValidationErrorEnvelope(CustomApplicationValidationException exception)
    {
        var errors = exception.Errors
            .SelectMany(kvp => kvp.Value.Select(error => new { Field = kvp.Key, Error = error }))
            .ToDictionary(x => x.Field, x => x.Error);

        var errorMessage = string.Join("; ", errors.Select(e => $"{e.Key}: {e.Value}"));
        return Envelope.Create(errorMessage, HttpStatusCode.BadRequest);
    }
}
