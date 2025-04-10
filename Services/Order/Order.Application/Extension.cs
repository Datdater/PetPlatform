using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Order.Application
{
    public static class Extension
    {
        public static IServiceCollection ApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );
            return services;
        }

    }
}
