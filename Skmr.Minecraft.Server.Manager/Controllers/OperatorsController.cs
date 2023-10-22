using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Skmr.Minecraft.Server.Manager.Models;

namespace Skmr.Minecraft.Server.Manager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperatorsController : ControllerBase
    {
        private readonly ILogger<OperatorsController> _logger;
        private readonly string _path;
        public OperatorsController(ILogger<OperatorsController> logger)
        {
            _logger = logger;
            _path = Environment.GetEnvironmentVariable("MINECRAFT_SERVER") + "\\ops.json";
        }
        
        [HttpGet]
        public Operator[] Get()
        {
            Operator[] result = new Operator[0];
            using (StreamReader sr = new StreamReader(_path, false))
            {
                var content = sr.ReadToEnd();
                result = JsonConvert.DeserializeObject<Operator[]>(content);
            }

            return result;
        }
    }
}
