using ETicaretAPI.Application.Dtos.Products;
using FluentValidation.AspNetCore;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<ProductCreateDto>();
            return services;
        }
    }
}
