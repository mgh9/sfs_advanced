namespace SFSAdv.Domain.Aggregates.ProductAggregate.Services;

public interface IProductService
{
    Task EnsureProductTitleIsUniqueAsync(string title, CancellationToken cancellationToken);
}
