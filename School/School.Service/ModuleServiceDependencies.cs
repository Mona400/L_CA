using Microsoft.Extensions.DependencyInjection;
using School.Service.Abstracts;
using School.Service.Implementation;

namespace School.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServicesDependencies( this IServiceCollection services)
        {
            services.AddTransient<IStudentServices, Studentservices>();
            return services;
        }
    }
}