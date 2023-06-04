namespace BlackRock;

internal static class Program
{
    public static void Main(string[] args)
    {
        Pages.DisplayLogo(); Setup();
        while (true)
        {
            Pages.BunkerManager();
        }
        // ReSharper disable once FunctionNeverReturns
    }

    private static void Setup()
    {
        Environment.CurrentDirectory = @"C:\Users\" + Environment.UserName + @"\Documents";
        if (!Directory.Exists(Environment.CurrentDirectory + @"\BlackRock"))
        {
            Directory.CreateDirectory(Environment.CurrentDirectory + @"\BlackRock");
        }
        Environment.CurrentDirectory += @"\BlackRock";
    }
}