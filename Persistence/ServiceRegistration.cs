
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;


namespace Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<AppointmentSystemDbContext>(ServiceLifetime.Singleton);
            return services;
        }
    }
}
