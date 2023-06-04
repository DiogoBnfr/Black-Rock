using Console = System.Console;

namespace BlackRock;

public static class Pages
{
    public static void DisplayLogo()
    {
        Console.Clear();
        for (int i = 0; i < Console.WindowHeight - 1; i++)
        {
            if (i == (Console.WindowHeight / 2) - 2) Interface.Center("B L A C K : R O C K");
            else Console.WriteLine();
        }
        Thread.Sleep(1000);
        Console.Clear();
    }
    
    public static void BunkerManager()
    {
        while (true)
        {
            Console.Clear();
            Interface.Center("B U N K E R : M A N A G E R", ':');
            FileHandler.OpenDirectory();
            Interface.Center("| 1 : Open bunker | 2 : Create bunker | 3 : Delete bunker | 4 : Exit |", ':');
            
            int[] options = { 1, 2, 3, 4 };
            int inputInt = Interface.IntPrompt(options);
            // ReSharper disable once ConvertIfStatementToSwitchStatement
            if (inputInt == 1)
            {
                try
                {
                    OpenBunker();
                }
                catch (DirectoryNotFoundException)
                {
                    Interface.Error("Directory you're trying to open doesn't exist!");
                }
            }
            if (inputInt == 2) CreateBunker();
            if (inputInt == 3) DeleteBunker();
            // ReSharper disable once InvertIf
            if (inputInt == 4) { DisplayLogo(); break; }
        }
    }

    private static void OpenBunker()
    {
        Interface.Center("O P E N : B U N K E R", ':');
        Console.Write("Bunker name: ");
        string directory = Console.ReadLine()!;
        
        FileManager(directory);
    }

    private static void CreateBunker()
    {
        while (true)
        {
            Interface.Center("C R E A T E : B U N K E R", ':');
            Console.Write("Bunker name: ");
            string directory = Console.ReadLine()!;

            if (Directory.Exists(Environment.CurrentDirectory + @"\" + directory))
            {
                Interface.Error("The current bunker already exists!");
            }
            else FileHandler.CreateDirectory(directory); break;
        }
        Console.Clear();
    }

    private static void DeleteBunker()
    {
        while (true)
        {
            Interface.Center("D E L E T E : B U N K E R", ':');
            Console.Write("Bunker name: ");
            string directory = Console.ReadLine()!;
            
            FileHandler.DeleteDirectory(directory); break;
        }
    }

    private static void FileManager(string directory)
    {
        bool run = true;
        while (true)
        {
            Console.Clear();
            Interface.Center("F I L E : M A N A G E R", ':');
            if (run) { FileHandler.OpenDirectory(directory); run = false; }
            else FileHandler.OpenDirectory();
            Interface.Center("| 1 : Open file | 2 : Create file | 3 : Delete file | 4 : Exit |", ':');

            int[] options = { 1, 2, 3, 4 };
            int inputInt = Interface.IntPrompt(options);
            // ReSharper disable once ConvertIfStatementToSwitchStatement
            if (inputInt == 1) OpenFile();
            if (inputInt == 2) CreateFile();
            if (inputInt == 3) DeleteFile();
            // ReSharper disable once InvertIf
            if (inputInt == 4) { Environment.CurrentDirectory = Program.Root(); break; }
        }
    }

    private static void OpenFile()
    {
        
    }

    private static void CreateFile()
    {
        Interface.Center("C R E A T E : F I L E", ':');
        Console.Write("File name: ");
        string fileName = Console.ReadLine()!;
        Console.Write("File extension (default = txt): ");
        string fileExtension = Console.ReadLine()!;
        
        FileHandler.CreateFile(fileName, fileExtension);
    }

    private static void DeleteFile()
    {
        Interface.Center("D E L E T E : F I L E", ':');
        Console.Write("File name: ");
        string fileName = Console.ReadLine()!;
        
        FileHandler.DeleteFile(@"\" + fileName);
    }
}

public static class Interface
{
    public static void Center(string text, char symbol = ' ')
    {
        int padding = Console.WindowWidth / 2 - text.Length / 2 - 2;
        
        for (int i = 0; i < padding; i++) Console.Write(symbol);
        Console.Write(' ' + text + ' ');
        for (int i = 0; i < padding; i++) Console.Write(symbol);
        
        Console.WriteLine();
    }

    // ReSharper disable once ParameterTypeCanBeEnumerable.Global
    public static int IntPrompt(int[] options)
    {
        Console.Write("Insert an option: ");

        try
        {
            int input = Convert.ToInt32(Console.ReadLine());
            if (options.Any(option => input == option)) return input;

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

    public static void Error(string exception)
    {
        Console.Clear(); 
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(); 
        Center(exception, ' '); 
        Console.WriteLine();
        Thread.Sleep(1000);
        Console.ResetColor(); Console.Clear();
    }

    public static void Success(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine();
        Center(message);
        Console.WriteLine();
        Thread.Sleep(1000);
        Console.ResetColor();
    }
}
