using Newtonsoft.Json;

namespace Skmr.Minecraft.Server.Manager.Models
{
    public class UserCache
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        [JsonProperty("expiresOn")]
        public string ExpiresOn { get; set; }
    }
}
