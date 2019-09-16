using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRChat.Hubs;

namespace SignalRServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        IHubContext<BroacastHub> messageHubContext;
        public MessageController(IHubContext<BroacastHub> messageHubContext)
        {
            this.messageHubContext = messageHubContext;
        }

        [HttpGet]
        public async Task<JsonResult> Get(string user, string message, string connId)
        {
            if(string.IsNullOrEmpty(connId)){
                await this.messageHubContext.Clients.All.SendAsync("ReceiveMessage", user, message);
            }
            else {
                await this.messageHubContext.Clients.Client(connId).SendAsync("ReceiveMessage", user, message);
            }
            return new JsonResult("Sent");
        }
            
    }
}
