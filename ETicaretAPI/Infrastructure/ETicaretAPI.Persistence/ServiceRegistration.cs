using ETicaretAPI.Application.Repositories.Interfaces.Customers;
using ETicaretAPI.Application.Repositories.Interfaces.Orders;
using ETicaretAPI.Application.Repositories.Interfaces.Products;
using ETicaretAPI.Persistence.Contexts;
using ETicaretAPI.Persistence.Helpers;
using ETicaretAPI.Persistence.Repositories.Implements.Orders;
using ETicaretAPI.Persistence.Repositories.Implements.Products;
using ETicaretAPI.Persistence.Repositories.Implements.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        static IServiceCollection AddPostgreSQLContext(this IServiceCollection services)
        {
            services.AddDbContext<PostgreSQLDbContext>(x => x.UseNpgsql(DatabaseConfig.GetConnectionString()));
            return services;
        }

        static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            return services;
        }

        public static IServiceCollection AddBussinesLayer(this IServiceCollection services)
        {
            services.AddPostgreSQLContext();
            services.AddRepositories();
            return services;
        }
    }
}
