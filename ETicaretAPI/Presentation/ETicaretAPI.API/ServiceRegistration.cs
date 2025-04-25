using ETicaretAPI.Application;
using ETicaretAPI.Infrastructure;
using ETicaretAPI.Infrastructure.Services.Implements.Storage.Local;
using ETicaretAPI.Persistence;
using Microsoft.Extensions.Options;

namespace ETicaretAPI.API
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPresentationLayer(this IServiceCollection services,Jwt jwtOptions)
        {
            services.AddPersistenceLayer();
            services.AddInfrastructureLayer<LocalStorage>(jwtOptions);
            services.AddApplicationLayer();
            services.AddHttpContextAccessor();
            return services;
        }
    }
}
