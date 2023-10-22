using System.Diagnostics;

HttpClient client = new HttpClient();
string serverUrl = "https://localhost:7166";
string processName = "javaw";

while (true)
{
    var thisProcess = Process.GetCurrentProcess();
    var processes = Process.GetProcesses();
    var minecraftProcesses = processes.Where((x) => x.ProcessName.ToLower().Contains(processName) && x.Id != thisProcess.Id).ToArray();

    //Sends server message, that a player is online

    Console.Clear();

    if (minecraftProcesses.Any())
    {
        Console.WriteLine("Minecraft is online");
        
        //try to reache server
        var values = new Dictionary<string, string>
        {

        };

        var content = new FormUrlEncodedContent(values);

        var response = await client.PostAsync(serverUrl+ "/Uptime", content);

        var responseString = await response.Content.ReadAsStringAsync();

        //if server can not be reached, try to start server

        if (responseString == String.Empty)
        {
            //Start server
        }
    }

    //Wait till next call
    Thread.Sleep(1000);
}
