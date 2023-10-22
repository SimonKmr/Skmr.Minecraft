using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Skmr.Minecraft.Server.Manager.Models;

namespace Skmr.Minecraft.Server.Manager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BannedPlayersController : ControllerBase
    {
        private readonly ILogger<BannedPlayersController> _logger;
        private readonly string _path;

        public BannedPlayersController(ILogger<BannedPlayersController> logger)
        {
            _logger = logger;
            _path = Environment.GetEnvironmentVariable("MINECRAFT_SERVER") + "\\banned-players.json";
        }
        
        [HttpGet]
        public BannedPlayer[] Get()
        {
            BannedPlayer[] result = new BannedPlayer[0];
            using (StreamReader sr = new StreamReader(_path, false))
            {
                var content = sr.ReadToEnd();
                result = JsonConvert.DeserializeObject<BannedPlayer[]>(content);
            }

            return result;
        }
    }
}
