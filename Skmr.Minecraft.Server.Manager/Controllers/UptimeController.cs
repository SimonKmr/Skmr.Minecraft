using Microsoft.AspNetCore.Mvc;
using Skmr.Minecraft.Server.Manager.Models;
using System.Diagnostics;
using System.Runtime.InteropServices;

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

        [HttpDelete]
        public void Delete()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("/bin/bash", "shutdown -h now");
            }
            Console.WriteLine("Delete Executed...");
        }
    }
}
