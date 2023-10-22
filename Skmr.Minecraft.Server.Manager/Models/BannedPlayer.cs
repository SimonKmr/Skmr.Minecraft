using Newtonsoft.Json;

namespace Skmr.Minecraft.Server.Manager.Models
{
    public class BannedPlayer
    {
        [JsonProperty("uuid")]
        public string UUID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("expires")]
        public string Expires { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
