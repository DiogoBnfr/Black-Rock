namespace BlackRock;

internal static class Program
{
    public static void Main(string[] args)
    {
        Setup(); Pages.DisplayLogo();
        while (true)
        { 
            Pages.BunkerManager();
            break;
        }
        // ReSharper disable once FunctionNeverReturns
    }

    private static void Setup()
    {
        Console.Title = "Black Rock";
        Environment.CurrentDirectory = @"C:\Users\" + Environment.UserName + @"\Documents";

        if (!Directory.Exists(Environment.CurrentDirectory + @"\BlackRock"))
        {
            Directory.CreateDirectory(Environment.CurrentDirectory + @"\BlackRock");
        }
        Environment.CurrentDirectory += @"\BlackRock";
    }

    public static string Root()
    {
        return @"C:\Users\" + Environment.UserName + @"\Documents\BlackRock";
    }
}