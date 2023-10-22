using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace Skmr.Minecraft.Server.Manager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BannedIpsController : ControllerBase
    {
        private readonly ILogger<BannedIpsController> _logger;
        private readonly string _path;
        public BannedIpsController(ILogger<BannedIpsController> logger)
        {
            _logger = logger;
            _path = Environment.GetEnvironmentVariable("MINECRAFT_SERVER") + "\\banned-ips.json";
        }
        
        [HttpGet]
        public string[] Get()
        {
            string[] result = new string[0];
            using (StreamReader sr = new StreamReader(_path, false))
            {
                var content = sr.ReadToEnd();
                result = JsonConvert.DeserializeObject<string[]>(content);
            }

            return result;
        }
    }
}
