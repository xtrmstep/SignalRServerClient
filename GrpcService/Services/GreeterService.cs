using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace GrpcService
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly IHubContext<NotificationsHub> _hubContext;

        public GreeterService(ILogger<GreeterService> logger, IHubContext<NotificationsHub> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        public override async Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", "from grpc");
            
            return await Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}