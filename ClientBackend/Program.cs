using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ClientBackend
{
    public class Program
    {
        public static HubConnection hub;

        public static void Main(string[] args)
        {
            hub = new HubConnectionBuilder()
                .WithUrl("http://localhost:5001/hubs")
                .WithAutomaticReconnect()
                .Build();
            hub.On<string>("ReceiveMessage", text =>
            {
                Debug.WriteLine($"Notification received: {text}");
            });
            hub.StartAsync().GetAwaiter().GetResult();
            
            CreateHostBuilder(args).Build().Run();
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}