using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SFSAdv.Domain.Abstractions.Persistence;
using SFSAdv.Domain.Aggregates.OrderAggregate;
using SFSAdv.Domain.Aggregates.ProductAggregate.Entities;
using SFSAdv.Domain.Aggregates.UserAggregate;
using SFSAdv.Infrastructure.Persistence;
using SFSAdv.Infrastructure.Persistence.Repositories;

namespace SFSAdv.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}
