using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Server
{
    public class NotificationsHub : Hub
    {
        public Task ShowMessage(string message)
        {
            return Clients.All.SendAsync("ShowMessage", message);
        }
        
        public override async Task OnConnectedAsync()
        {
            Debug.WriteLine($"New connection: {Context.ConnectionId}");
            await base.OnConnectedAsync();
        }
        
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            Debug.WriteLine($"Disconnecting: {Context.ConnectionId}");
            await base.OnDisconnectedAsync(exception);
        }
    }
}