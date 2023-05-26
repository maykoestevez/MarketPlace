using MarketPlace.Infrastructure.Database;
using MarketPlace.Infrastructure.Interfaces.Repository;
using MarketPlace.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MarketPlace.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddDbContext<MarketPlaceDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("MarketPlaceDb"),
                b => b.MigrationsAssembly("MarketPlace.api")));
        return services;
    }
}