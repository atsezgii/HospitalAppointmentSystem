

namespace Infrastructure.SignalR.HubService
{
    public interface ILiveChatHubService
    {
        Task GetMessageAsync(string message);
    }
}
