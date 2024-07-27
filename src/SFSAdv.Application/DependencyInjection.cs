using Microsoft.Extensions.DependencyInjection;
using SFSAdv.Application.Products.Services;
using SFSAdv.Domain.Aggregates.ProductAggregate.Services;

namespace SFSAdv.Application;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        });
        services.AddScoped<IProductService, ProductService>();
    }
}
