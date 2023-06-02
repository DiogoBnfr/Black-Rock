using Console = System.Console;

namespace BlackRock;

public static class Pages
{
    public static int BunkerManager()
    {
        int input;
        while (true)
        {
            Interface.Center("BLACK ROCK", ':');
            FileHandler.ScanRoot();
            Interface.Center("| 1 : Open bunker | 2 : Create bunker | 3 : Delete bunker |", ':');
            
            int[] options = { 1, 2, 3 };
            input = Interface.Prompt(options);
            if (input != -1) break; 
        }
        return input;
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

    public static int Prompt(int[] options)
    {
        Console.Write("Insert an option: ");

        try
        {
            int input = Convert.ToInt32(Console.ReadLine());

            foreach (int option in options)
            {
                if (input == option)
                {
                    return input;
                }
            }

            Error("Invalid input! Please try again.");
        }
        catch (FormatException)
        {
            Error("Invalid type! Please insert an integer.");
        }
        catch (ArgumentOutOfRangeException)
        {
            Error("Invalid input! Please insert an existent option.");
        }
        catch (OverflowException)
        {
            Error("Invalid input! ...");
        }
        return -1;
    }

    private static void Error(string exception)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(); Interface.Center(exception, ' '); Console.WriteLine();
        Thread.Sleep(1000);
        Console.ResetColor();
        Console.Clear();
    }
}
