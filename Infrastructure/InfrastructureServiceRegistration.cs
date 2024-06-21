using Infrastructure.SignalR.HubService;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<ILiveChatHubService, LiveChatHubService>();
            services.AddSignalR();
            return services;
        }
    }
}
