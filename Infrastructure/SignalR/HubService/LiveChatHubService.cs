using Infrastructure.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;


namespace Infrastructure.SignalR.HubService
{
    public class LiveChatHubService : ILiveChatHubService
    {
        private readonly IHubContext<LiveChatHub> _hubContext;

        public LiveChatHubService(IHubContext<LiveChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task GetMessageAsync(string message) //ang servisteki procedureName
        {
            await _hubContext.Clients.All.SendAsync("receiveLiveChatMessage", message);
        }
    }
}
