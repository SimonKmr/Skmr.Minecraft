using Microsoft.AspNetCore.Mvc;
using Skmr.Minecraft.Server.Manager.Models;

namespace Skmr.Minecraft.Server.Manager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly ILogger<PropertiesController> _logger;
        private readonly string _path;

        public PropertiesController(ILogger<PropertiesController> logger)
        {
            _logger = logger;
            _path = Environment.GetEnvironmentVariable("MINECRAFT_SERVER") + "\\server.properties";
        }

        [HttpGet]
        public Properties Get()
        {
            Properties result;
            
            using (StreamReader sr = new StreamReader(_path))
            {
                var content = sr.ReadToEnd();
                result = TextToProps(content);
            }

            return result;
        }

        [HttpPut]
        public void Set(Properties properties)
        {
            using(StreamWriter sw = new StreamWriter(_path, false))
            {
                var content = PropsToText(properties);
                sw.Write(content);
            }
        }

        private Properties TextToProps(string content)
        {
            return new Properties();
        }

        private string PropsToText(Properties properties)
        {
            return String.Empty;
        }
    }
}
