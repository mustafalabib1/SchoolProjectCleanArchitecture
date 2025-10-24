using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Service.Implemention;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            // Add service layer dependencies here
            // e.g., services.AddScoped<IYourService, YourServiceImplementation>();
            services.AddTransient<IStudentService, StudentService>();
            return services;
        }
    }
}
