using ETicaretAPI.Application.Services.Interfaces;
using ETicaretAPI.Application.Services.Interfaces.Storage;
using ETicaretAPI.Infrastructure.Services.Implements;
using ETicaretAPI.Infrastructure.Services.Implements.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStorageService, StorageService>();
            return services;
        }

        public static IServiceCollection AddServicesInfrastructure<T>(this IServiceCollection services) where T : Storage, IStorage
        {
            services.AddServices();
            services.AddScoped<IStorage, T>();
            return services;
        }
    }
}
