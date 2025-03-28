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
using FluentValidation.AspNetCore;
using ETicaretAPI.Application.Dtos.Products;
using FluentValidation;
using ETicaretAPI.Application.Repositories.Interfaces.Files;
using ETicaretAPI.Persistence.Repositories.Implements.Files;
using ETicaretAPI.Application.Repositories.Interfaces.InvoiceFiles;
using ETicaretAPI.Persistence.Repositories.Implements.InvoiceFiles;
using ETicaretAPI.Application.Repositories.Interfaces.ProductImageFiles;
using ETicaretAPI.Persistence.Repositories.Implements.ProductImageFiles;

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
            services.AddScoped<IFileReadRepository, FileReadRepository>();
            services.AddScoped<IFileWriteRepository, FileWriteRepository>();
            services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
            services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();
            services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
            services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();
            return services;
        }

        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services)
        {
            services.AddPostgreSQLContext();
            services.AddRepositories();
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<ProductCreateDto>();
            return services;
        }
    }
}
