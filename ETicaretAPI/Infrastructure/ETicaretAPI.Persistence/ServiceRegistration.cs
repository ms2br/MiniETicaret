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
using ETicaretAPI.Application.Repositories.Interfaces.Files;
using ETicaretAPI.Persistence.Repositories.Implements.Files;
using ETicaretAPI.Application.Repositories.Interfaces.InvoiceFiles;
using ETicaretAPI.Persistence.Repositories.Implements.InvoiceFiles;
using ETicaretAPI.Application.Repositories.Interfaces.ProductImageFiles;
using ETicaretAPI.Persistence.Repositories.Implements.ProductImageFiles;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        static IServiceCollection AddPostgreSQLContext(this IServiceCollection services)
        {
            services.AddDbContext<PostgreSQLDbContext>(x => x.UseNpgsql(DatabaseConfig.GetConnectionString()))
                .AddIdentity<AppUser, IdentityRole>(opt =>
                {
                    opt.SignIn.RequireConfirmedEmail = true;
                    opt.SignIn.RequireConfirmedAccount = true;
                    opt.Password.RequireLowercase = true;
                    opt.Password.RequireUppercase = true;
                    opt.Password.RequireNonAlphanumeric = true;
                    opt.Password.RequiredLength = 6;
                    opt.User.RequireUniqueEmail = true;
                    opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_  ";
                    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(3);
                    opt.Lockout.AllowedForNewUsers = true;
                    opt.Lockout.MaxFailedAccessAttempts = 5;
                })
                .AddEntityFrameworkStores<PostgreSQLDbContext>()
                .AddDefaultTokenProviders();
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
            return services;
        }
    }
}
