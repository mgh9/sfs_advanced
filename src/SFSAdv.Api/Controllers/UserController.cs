using MediatR;
using Microsoft.AspNetCore.Mvc;
using SFSAdv.Application.Users.Queries.GetUsers;
using SFSAdv.Domain.Aggregates.UserAggregate.ReadModels;

namespace SFSAdv.Api.Controllers;

[ApiController]
[Route("api/users")]
[Produces("application/json")]
public class UserController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger, ISender mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<UserReadModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken = default)
    {
        var users = await _mediator.Send(new GetUsersQuery(), cancellationToken);
        return Ok(users);
    }
}
