using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HubMethodsController : ControllerBase
    {
        private readonly ILogger<HubMethodsController> _logger;
        private readonly IHubContext<NotificationsHub> _hubContext;

        public HubMethodsController(ILogger<HubMethodsController> logger, IHubContext<NotificationsHub> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string text)
        {
            await Task.Yield();
            
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", text);
            return Ok();
        }
    }
}