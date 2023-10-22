using Microsoft.AspNetCore.Mvc;
using Skmr.Minecraft.Server.Manager.Models;

namespace Skmr.Minecraft.Server.Manager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UptimeController : ControllerBase
    {
        private readonly ILogger<PropertiesController> _logger;
        public UptimeController(ILogger<PropertiesController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public void Add()
        {
            UptimeManager.Instance.Ping();
        }

        [HttpGet]
        public Uptime Get()
        {
            var m = UptimeManager.Instance;
            return new Uptime()
            {
                LastPing = m.LastPing,
                Started = m.Started,
                Threshold = m.Threshold
            };
            
        }
    }
}
