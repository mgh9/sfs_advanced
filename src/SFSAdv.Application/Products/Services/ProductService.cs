using SFSAdv.Domain.Abstractions.Exceptions;
using SFSAdv.Domain.Aggregates.ProductAggregate.Entities;
using SFSAdv.Domain.Aggregates.ProductAggregate.Services;

namespace SFSAdv.Application.Products.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task EnsureProductTitleIsUniqueAsync(string title, CancellationToken cancellationToken)
    {
        if (await _productRepository.GetByTitleAsync(title, cancellationToken) is not null)
        {
            throw new DomainValidationException("Product title must be unique.");
        }
    }
}
