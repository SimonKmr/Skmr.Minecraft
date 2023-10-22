namespace Skmr.Minecraft.Server.Manager.Models
{
    public class Uptime
    {
        public DateTime LastPing { get; set; }
        public DateTime Started { get; set; }
        public TimeSpan Threshold { get; set; }
    }
}
