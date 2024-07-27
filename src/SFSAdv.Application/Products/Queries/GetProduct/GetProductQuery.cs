using SFSAdv.Application.Abstractions.Queries;
using SFSAdv.Domain.Aggregates.ProductAggregate.ReadModels;

namespace SFSAdv.Application.Products.Queries.GetProduct;

public sealed record GetProductQuery(Guid Id) : Query<ProductReadModel?>;
