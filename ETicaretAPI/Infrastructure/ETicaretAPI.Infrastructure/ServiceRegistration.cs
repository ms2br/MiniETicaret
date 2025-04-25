using ETicaretAPI.Application.ExternalServices.Interfaces;
using ETicaretAPI.Application.Services.Interfaces;
using ETicaretAPI.Application.Services.Interfaces.Paginations;
using ETicaretAPI.Application.Services.Interfaces.Storage;
using ETicaretAPI.Infrastructure.ExternalServices.Implements;
using ETicaretAPI.Infrastructure.Services.Implements;
using ETicaretAPI.Infrastructure.Services.Implements.Paginations;
using ETicaretAPI.Infrastructure.Services.Implements.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ETicaretAPI.Infrastructure
{
    public class Jwt
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SigningKey { get; set; }
        public int ValidityMinute { get; set; }
    }

    public static class ServiceRegistration
    {
        static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<IRequestInfoService, RequestInfoService>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }

        static IServiceCollection AddAuth(this IServiceCollection services,Jwt jwtOptions)
        {
            services.AddAuthentication()
                .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,

                    ValidAudience = jwtOptions.Audience,
                    ValidIssuer = jwtOptions.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SigningKey)),
                    LifetimeValidator = (_, expires, _, _) => expires != null ? expires > DateTime.UtcNow : false
                };
            });
            return services;
        }

        public static IServiceCollection AddInfrastructureLayer<T>(this IServiceCollection services, Jwt jwtOptions) where T : Storage, IStorage
        {
            services.AddServices();
            services.AddAuth(jwtOptions);
            services.AddScoped<IStorage, T>();
            return services;
        }
    }
}
