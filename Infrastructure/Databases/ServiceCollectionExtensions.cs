using Infrastructure.Databases.CustomerDatabase;
using Infrastructure.Databases.CustomerDatabase.Interfaces;
using Infrastructure.Databases.OrdersDatabase;
using Infrastructure.Databases.OrdersDatabase.Interfaces;
using Infrastructure.Databases.ProductsDatabase;
using Infrastructure.Databases.ProductsDatabase.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Databases
{
    internal static class ServiceCollectionExtensions
    {
        internal static void AddDatabases(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CustomerDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CustomerDatabase")));
            services.AddScoped<CustomerUnitOfWork>();

            services.AddDbContext<OrderDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("OrdersDatabase")));
            services.AddScoped<OrderUnitOfWork>();

            services.AddDbContext<ProductDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ProductsDatabase")));
            services.AddScoped<ProductUnitOfWork>();
        }
    }
}
