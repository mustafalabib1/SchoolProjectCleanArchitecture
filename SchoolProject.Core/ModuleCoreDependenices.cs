using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core
{
    public static class ModuleCoreDependenices
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            // Register core services, handlers, validators,MediatR, AutoMapper , etc.
            // Configure MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ModuleCoreDependenices).Assembly));
            // Configure AutoMapper 
            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(ModuleCoreDependenices).Assembly));
            return services;
        }
    }
}
