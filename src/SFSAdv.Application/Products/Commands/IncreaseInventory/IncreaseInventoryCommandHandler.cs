using Microsoft.Extensions.Logging;
using SFSAdv.Application.Abstractions.Commands;
using SFSAdv.Application.Abstractions.Persistence;
using SFSAdv.Domain.Abstractions.Exceptions;
using SFSAdv.Domain.Aggregates.ProductAggregate.Entities;

namespace SFSAdv.Application.Products.Commands.IncreaseInventory;

internal class IncreaseInventoryCommandHandler : CommandHandler<IncreaseInventoryCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<IncreaseInventoryCommandHandler> _logger;

    public IncreaseInventoryCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, ILogger<IncreaseInventoryCommandHandler> logger)
        : base(unitOfWork)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    protected override async Task HandleAsync(IncreaseInventoryCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetAsync(request.ProductId, cancellationToken)
                        ?? throw new NotFoundException("Product not found");

        product.IncreaseInventory(request.Amount);
        _productRepository.Update(product);

        await UnitOfWork.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("The Product (id: `{id}`) inventory increased by `{amount}`", request.ProductId, request.Amount);
    }
}
