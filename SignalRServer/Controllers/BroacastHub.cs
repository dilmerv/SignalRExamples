using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    public class BroacastHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendMessageToClient(string user, string message, string connectionId)
        {
            await Clients.Client(connectionId).SendAsync("ReceiveMessage", user, message);
        }
    }
}