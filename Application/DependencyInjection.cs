namespace Application
{
    using System.Reflection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            /*services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
                */
            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssembly(
                    typeof(DependencyInjection).Assembly));
            
            return services;
        }
    }
}