using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using SFSAdv.Application.Abstractions.Queries;
using SFSAdv.Domain.Aggregates.ProductAggregate.Entities;
using SFSAdv.Domain.Aggregates.ProductAggregate.ReadModels;

namespace SFSAdv.Application.Products.Queries.GetProduct;

public sealed class GetProductQueryHandler : QueryHandler<GetProductQuery, ProductReadModel?>
{
    private readonly IMemoryCache _cache;
    private readonly IProductRepository _productRepository;

    public GetProductQueryHandler(IMapper mapper, IMemoryCache cache, IProductRepository productRepository)
        : base(mapper)
    {
        this._cache = cache;
        _productRepository = productRepository;
    }

    protected async override Task<ProductReadModel?> HandleAsync(GetProductQuery request, CancellationToken cancellationToken)
    {
        if(!_cache.TryGetValue(GetProductCacheKey(request.Id), out ProductReadModel? theProductReadModel))
        {
            var theProduct = await _productRepository.GetAsync(request.Id, cancellationToken: cancellationToken);
            if(theProduct is null)
            {
                return null;
            }

            theProductReadModel = Mapper.Map<ProductReadModel>(theProduct);
            theProductReadModel.FinalPrice = theProduct.CalculateFinalPrice();

            CacheProduct(theProductReadModel);
        }

        return theProductReadModel;
    }

    private void CacheProduct(ProductReadModel model)
    {
        var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(1));

        var theCacheKey = GetProductCacheKey(model.Id);
        _cache.Set(theCacheKey, model, cacheEntryOptions);
    }

    private static string GetProductCacheKey(Guid id)
    {
        return $"products:{id}";
    }
}
