using Microsoft.Extensions.Logging;
using SFSAdv.Application.Abstractions.Commands;
using SFSAdv.Application.Abstractions.Persistence;
using SFSAdv.Domain.Aggregates.ProductAggregate.Entities;
using SFSAdv.Domain.Aggregates.ProductAggregate.Services;

namespace SFSAdv.Application.Products.Commands.AddProduct;

internal class AddProductCommandHandler : CommandHandler<AddProductCommand, Guid>
{
    private readonly IProductService _productService;
    private readonly IProductRepository _productRepository;
    private readonly ILogger<AddProductCommandHandler> _logger;

    public AddProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, ILogger<AddProductCommandHandler> logger, IProductService productService)
        : base(unitOfWork)
    {
        _productRepository = productRepository;
        _productService = productService;
        _logger = logger;
    }

    protected override async Task<Guid> HandleAsync(AddProductCommand request, CancellationToken cancellationToken)
    {
        await _productService.EnsureProductTitleIsUniqueAsync(request.Title, cancellationToken);

        var product = Product.CreateWithDefaults(request.Title, request.InventoryCount, request.Price, request.Discount);
        await _productRepository.AddAsync(product, cancellationToken);

        await UnitOfWork.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Product `{productId}` successfully added in the Inventory", product.Id);

        return product.Id;
    }
}
