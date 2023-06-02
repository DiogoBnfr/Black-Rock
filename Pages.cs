namespace BlackRock;

public static class Pages
{
    public static void BunkerManager()
    {
        Interface.Center("BLACK ROCK", ':');
        FileHandler.ScanRoot();
        Interface.Center("| 1 : Open bunker | 2 : Create bunker | 3 : Delete bunker |", ':');
    }

    public static void DepositManager()
    {
        
    }

    public static void NoteManager()
    {
        
    }
}

public static class Interface
{
    public static void Center(string text, char symbol)
    {
        int padding = Console.WindowWidth / 2 - text.Length / 2 - 2;
        
        for (int i = 0; i < padding; i++) Console.Write(symbol);
        Console.Write(' ' + text + ' ');
        for (int i = 0; i < padding; i++) Console.Write(symbol);
        
        Console.WriteLine();
    }
}
