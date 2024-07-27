using MediatR;
using Microsoft.AspNetCore.Mvc;
using SFSAdv.Api.Infrastructure.ActionResults;
using SFSAdv.Application.Orders.Models;
using SFSAdv.Application.Products.Commands.AddProduct;

namespace SFSAdv.Api.Controllers;

[ApiController]
[Route("api/orders")]
[Produces("application/json")]
public class OrderController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly ILogger<OrderController> _logger;

    public OrderController(ILogger<OrderController> logger, ISender mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost("buy")]
    [ProducesResponseType(typeof(CreatedResultEnvelope), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(Envelope), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Envelope), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> BuyAsync([FromBody] BuyProductDto request, CancellationToken cancellationToken = default)
    {
        var orderId = await _mediator.Send(new BuyProductCommand(request.BuyerUserId, request.ProductId), cancellationToken);
        return StatusCode(StatusCodes.Status201Created, new CreatedResultEnvelope(orderId));
    }
}
