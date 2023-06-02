namespace BlackRock;

internal static class Program
{
    public static void Main(string[] args)
    {
        Environment.CurrentDirectory = @"C:\Users\" + Environment.UserName + @"\Documents";
        if (!Directory.Exists(Environment.CurrentDirectory + @"\BlackRock")) FileHandler.CreateRoot();
        Environment.CurrentDirectory += @"\BlackRock";
        
        Pages.BunkerManager();
    }
}