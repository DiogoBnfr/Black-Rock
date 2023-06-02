namespace BlackRock;

public static class FileHandler
{
    public static void CreateRoot()
    {
        Directory.CreateDirectory(Environment.CurrentDirectory + @"\BlackRock");
    }

    public static void ScanRoot()
    {
        string[] files = Directory.GetFiles(Environment.CurrentDirectory);
        if (files.Length == 0)
        { Console.WriteLine(); Interface.Center("You don't have any bunkers yet.", ' '); Console.WriteLine(); }
        foreach (string file in files) Console.WriteLine(file);
    }
    
    public static void CreateBunker()
    {
               
    }

    public static void DeleteBunker()
    {
        
    }

    public static void ScanBunker()
    {
        
    }

    public static void CreateDeposit()
    {
        
    }

    public static void DeleteDeposit()
    {
        
    }

    public static void ScanDeposit()
    {
        
    }

    public static void CreateNote()
    {
        
    }

    public static void EditNote()
    {
        
    }

    public static void DeleteNote()
    {
        
    }
}
