using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Skmr.Minecraft.Server.Manager
{
    public class UptimeManager
    {
        public static UptimeManager Instance { get; private set; }

        public static void Init()
        {
            Instance = new UptimeManager();
        }

        Thread _thread;
        public DateTime LastPing { get; private set; }
        public DateTime Started { get; }
        public TimeSpan Threshold { get; set; } = TimeSpan.FromMinutes(10);

        public UptimeManager()
        {
            _thread = new Thread(Run);
            _thread.Name = "Uptime Manager";
            _thread.Start();
            Started = DateTime.Now;
            LastPing = DateTime.Now;
        }

        private void Run()
        {
            Thread.Sleep(1000);
            while (true)
            {
                var delta = DateTime.Now - LastPing;

                if(delta > Threshold)
                {
                    ShuttingDown(this,EventArgs.Empty);
                    //Shut down Pc
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        Process.Start("/bin/bash", "shutdown -h now");
                    }
                    
                    Console.WriteLine("shutting down...");
                }

                Thread.Sleep(1000);
            }
        }

        public void Ping()
        {
            LastPing = DateTime.Now;
        }

        public event EventHandler ShuttingDown = (sender, args) => { };
}
}
