using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrastructure.Implmention;
using SchoolProject.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddfrastructureDependencies(this IServiceCollection services)
        {
            {
                services.AddTransient<IUniteOfWork, UnitOfWork>();
                return services;
            }
        }
    }
}