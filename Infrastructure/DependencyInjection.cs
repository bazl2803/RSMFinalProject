namespace Infrastructure
{
    using Application.Abstractions;
    using Authentication;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services)
        {
            services.AddTransient<IJwtProvider, JwtProvider>();
            return services;
        }
    }
}