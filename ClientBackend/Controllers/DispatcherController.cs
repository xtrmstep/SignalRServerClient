using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;

namespace ClientBackend.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DispatcherController : ControllerBase
    {
        private readonly ILogger<DispatcherController> _logger;        

        public DispatcherController(ILogger<DispatcherController> logger)
        {
            _logger = logger;            
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string text)
        {
            await Task.Yield();
            
            await Program.hub.InvokeAsync("ReceiveMessage", text);
                
            return Ok();
        }
    }
}