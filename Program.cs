namespace BlackRock;

internal static class Program
{
    public static void Main(string[] args)
    {
        int inputInt = 0; 
        Pages.DisplayLogo();
        Setup();

        while (true)
        {
            switch (inputInt)
            {
                case 0:
                    Pages.BunkerManager();
                    break;
                case 1:
                    Pages.DepositManager();
                    break;
                case 2:
                    Pages.NoteManager();
                    break;
            }   
        }
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