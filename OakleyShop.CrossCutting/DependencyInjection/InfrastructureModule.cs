using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OakleyShop.Application.Services;
using OakleyShop.Data.DatabaseContext;
using OakleyShop.Data.Repositories;
using OakleyShop.Domain.Interfaces.Repositories;
using OakleyShop.Domain.Interfaces.Services;

namespace OakleyShop.CrossCutting.DependencyInjection
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddRepositories();

            services.AddDbContext<ApplicationDbContext>(opts =>
            {
                string connectionSql = configuration.GetConnectionString("OakleySql")!;
                opts.UseSqlServer(connectionSql);

            });


            return services;
        }
        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
            //services.AddScoped(typeof(IProductService), typeof(ProductService));

            return services;
        }

    }
}
