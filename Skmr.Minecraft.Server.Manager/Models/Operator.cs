using Newtonsoft.Json;

namespace Skmr.Minecraft.Server.Manager.Models
{
    public class Operator
    {
        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("level")]
        public long Level { get; set; }

        [JsonProperty("bypassesPlayerLimit")]
        public bool BypassesPlayerLimit { get; set; }
    }
}
