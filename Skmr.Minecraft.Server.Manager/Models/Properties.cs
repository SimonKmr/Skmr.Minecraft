namespace Skmr.Minecraft.Server.Manager.Models
{
    public class Properties
    {
        public bool AllowFlight { get; set; }
        public bool AllowNether { get; set; }
        public bool BroadcastConsoleToOps { get; set; }
        public bool BroadcastRconToOps { get; set; }
        public bool Difficulty { get; set; }
        public bool EnableCommandBlock { get; set; }
        public bool EnableJmxMonitoring { get; set; }
        public bool EnableQuery { get; set; }
        public bool EnableRcon { get; set; }
        public bool EnableStatus { get; set; }
        public bool EnforceSecureProfile { get; set; }
        public bool EnforceWhitelist { get; set; }
        public int EntityBroadcastRangePercentage { get; set; }
        public bool ForceGamemode { get; set; }
        public int FunctionPermissionLevel { get; set; }
        public string Gamemode { get; set; }
        public bool GenerateStructures { get; set; }
        public string GeneratorSettings { get; set; }
        public bool Hardcore { get; set; }
        public bool HideOnlinePlayers { get; set; }
        public string InitialDisabledPackets { get; set; }
        public string InitialEnabledPackets { get; set; }
        public string LevelName { get; set; }
        public string LevelSeed { get; set; }
        public string LevelType { get; set; }
        public bool LogIps { get; set; }
        public int MaxChainedNeighborUpdates { get; set; }
        public int MaxPlayers { get; set; }
        public int MaxTickTime { get; set; }
        public int MaxWorldSize { get; set; }
        public string Motd { get; set; }
        public int NetworkCompressionThreshold { get; set; }
        public bool OnlineMode { get; set; }
        public int OpPermissionLevel { get; set; }
        public int PlayerIdelTimeout { get; set; }
        public bool PreventProxyConnections { get; set; }
        public bool Pvp { get; set; }
        public int QueryPort { get; set; }
        public int RateLimit { get; set; }
        public string RconPassword { get; set; }
        public int RconPort { get; set; }
        public bool RequireResourcePack { get; set; }
        public string ResourcePack { get; set; }
        public string ResourcePackPromt { get; set; }
        public string ResourcePackSha1 { get; set; }
        public string ServerIp { get; set; }
        public string ServerPort { get; set; }
        public int SimulationDistance { get; set; }
        public bool SpawnAnimals { get; set; }
        public bool SpawnMonsters { get; set; }
        public bool SpawnNpcs { get; set; }
        public int SpawnProtection { get; set; }
        public bool SyncChunkWrites { get; set; }
        public string TextFilteringConfig { get; set; }
        public string UseNativeTransport { get; set; }
        public int viewDistance { get; set; }
        public bool WhiteList { get; set; }

    }
}
