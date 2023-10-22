using Microsoft.AspNetCore.Mvc;

namespace Skmr.Minecraft.Server.Manager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServerController : ControllerBase
    {
        private readonly ILogger<ServerController> _logger;
        public ServerController(ILogger<ServerController> logger)
        {
            _logger = logger;
        }
        
        [HttpPost]
        public void Add(string text)
        {
            ServerManager.Instance.WriteToConsole(text);
        }

        [HttpGet]
        public string Get()
        {
            return ServerManager.Instance.ConsoleLog;
        }
    }
}
