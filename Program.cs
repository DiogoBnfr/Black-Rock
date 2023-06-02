namespace BlackRock;

internal static class Program
{
    public static void Main(string[] args)
    {
        Setup(); 
        Pages.BunkerManager();
    }

    private static void Setup()
    {
        Environment.CurrentDirectory = @"C:\Users\" + Environment.UserName + @"\Documents";
        if (!Directory.Exists(Environment.CurrentDirectory + @"\BlackRock"))
        {
            FileHandler.CreateRoot();
        }
        Environment.CurrentDirectory += @"\BlackRock";
    }
}