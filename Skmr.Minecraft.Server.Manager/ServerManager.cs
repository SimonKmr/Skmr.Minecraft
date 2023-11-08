using System.Diagnostics;

namespace Skmr.Minecraft.Server.Manager
{
    public class ServerManager
    {
        private Process _process;
        private Thread _consoleThread;
        public static ServerManager Instance { get; private set; }
        public static string Path { get; private set; }
        public string ConsoleLog { get; private set; }

        public static void Init()
        {
            Path = Environment.GetEnvironmentVariable("MINECRAFT_SERVER");
            Instance = new ServerManager();
        }

        public ServerManager()
        {
            var startInfo = new ProcessStartInfo()
            {
                WorkingDirectory = Path,
                FileName = "java" ,
                Arguments = "-jar " + Path + "\\" + "server.jar",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
            };

            _process = new Process()
            {
                StartInfo = startInfo,
            };

            _process.Start();

            _consoleThread = new Thread(UpdateConsoleLog);
            _consoleThread.Start();

            UptimeManager.Instance.ShuttingDown += Server_ShuttingDown;
        }

        internal int GetPlayersOnline()
        {
            WriteToConsole("list");
            UpdateConsoleLog();
            Console.WriteLine(ConsoleLog);
            return 0;
        }

        private void Server_ShuttingDown(object? sender, EventArgs e)
        {
            WriteToConsole("stop");
            _process.WaitForExit();
        }

        public void UpdateConsoleLog()
        {
            var output = _process.StandardOutput;

            while (!_process.HasExited)
            {
                var res = output.ReadLine();
                if(res != null)
                    ConsoleLog += res +"\n";
            }
        }

        public void WriteToConsole(string text)
        {
            var stdin = _process.StandardInput;
            stdin.WriteLine(text);
        }
    }
}
