using Console = System.Console;
using System.Runtime.InteropServices;

namespace BlackRock;

public static class Pages
{
    public static void DisplayLogo()
    {
        for (int i = 0; i < Console.WindowHeight - 1; i++)
        {
            if (i == (Console.WindowHeight / 2) - 2) Interface.Center("B L A C K : R O C K", ' ');
            else Console.WriteLine();
        }
        Console.Write("Loading".PadLeft(Console.WindowWidth - 6, ' '));
        Console.Write(" ."); Thread.Sleep(1000);
        Console.Write(" ."); Thread.Sleep(1000);
        Console.Write(" ."); Thread.Sleep(1000);
        Console.Clear();
    }
    
    public static int BunkerManager()
    {
        int inputInt;
        while (true)
        {
            Interface.Center("B U N K E R : M A N A G E R", ':');
            FileHandler.Scan();
            Interface.Center("| 1 : Open bunker | 2 : Create bunker | 3 : Delete bunker |", ':');
            
            int[] options = { 1, 2, 3 };
            inputInt = Interface.Prompt(options);
            if (inputInt != -1) break; 
        }
        return inputInt;
    }

    public static void CreateBunker()
    {
        
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
            if (options.Any(option => input == option)) return input;

            Error("Invalid input! Please try again.");
        }
        catch (FormatException) { Error("Invalid type! Please insert an integer."); }
        catch (ArgumentOutOfRangeException) { Error("Invalid input! Please insert an existent option."); }
        catch (OverflowException) { Error("Invalid input! ..."); }
        
        return -1;
    }

    private static void Error(string exception)
    {
        Console.Clear(); Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(); Interface.Center(exception, ' '); Console.WriteLine();
        Thread.Sleep(1000);
        Console.ResetColor(); Console.Clear();
    }
}
