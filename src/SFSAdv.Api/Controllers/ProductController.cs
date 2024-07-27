using MediatR;
using Microsoft.AspNetCore.Mvc;
using SFSAdv.Api.Infrastructure.ActionResults;
using SFSAdv.Application.Products.Commands.AddProduct;
using SFSAdv.Application.Products.Commands.IncreaseInventory;
using SFSAdv.Application.Products.Models;
using SFSAdv.Application.Products.Queries.GetProduct;
using SFSAdv.Domain.Aggregates.ProductAggregate.ReadModels;

namespace SFSAdv.Api.Controllers;

[ApiController]
[Route("api/products")]
[Produces("application/json")]
public class ProductController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger, ISender mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProductReadModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _mediator.Send(new GetProductQuery(id), cancellationToken);

        if (product is null)
        {
            return StatusCode(StatusCodes.Status404NotFound);
        }
        else
        {
            return StatusCode(StatusCodes.Status200OK, product);
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreatedResultEnvelope), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(Envelope), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Envelope), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddProductAsync([FromBody] AddProductDto request, CancellationToken cancellationToken = default)
    {
        var createdProductId = await _mediator.Send(new AddProductCommand(request.Title, request.InventoryCount, request.Price, request.Discount)
                                , cancellationToken);

        return StatusCode(StatusCodes.Status201Created, new CreatedResultEnvelope(createdProductId));
    }

    [HttpPut("{id}/inventory/{amount}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Envelope), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Envelope), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> IncreaseInventoryAsync(Guid id, int amount, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new IncreaseInventoryCommand(id, amount)
                            , cancellationToken);

        return NoContent();
    }
}
