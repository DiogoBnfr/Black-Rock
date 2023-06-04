namespace BlackRock;

public static class FileHandler
{
    private const int Delay = 1000;
    
    public static void OpenDirectory(string directory = "")
    {
        Environment.CurrentDirectory = Environment.CurrentDirectory + @"\" + directory;
        string[] files = Directory.GetFileSystemEntries(Environment.CurrentDirectory);
        if (files.Length == 0)
        {
            Console.WriteLine(); Interface.Center("You don't have any bunkers yet."); Console.WriteLine();
        }

        int initialIndex = Environment.CurrentDirectory.Length + 1;
        // if (directory != "") initialIndex += directory.Length + 1;  
        foreach (string file in files)
        {
            Console.WriteLine(file[(initialIndex)..]);
        }
    }
    
    public static void CreateDirectory(string directory)
    {
        try
        {
            Directory.CreateDirectory(Environment.CurrentDirectory + @"\" + directory);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Interface.Center("Bunker created!");
            Console.WriteLine();
            Thread.Sleep(Delay);
            Console.ResetColor();
        }
        catch (UnauthorizedAccessException)
        {
            Interface.Error("You don't have the necessary permission!");
        }
        catch (ArgumentException)
        {
            Interface.Error("File name contains invalid characters!");
        }
        catch (PathTooLongException)
        {
            Interface.Error("The current file path is too long!");
        }
        catch (SystemException)
        {
            Interface.Error("The current file already exists!");
        }
    }

    public static void DeleteDirectory(string directory)
    {
        try
        {
            Directory.Delete(Environment.CurrentDirectory + @"\" + directory);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Interface.Center("Bunker deleted!");
            Console.WriteLine();
            Thread.Sleep(Delay);
            Console.ResetColor();
        }
        catch (DirectoryNotFoundException)
        {
            Interface.Error("The bunker you're trying to delete doesn't exist!");
        }
        catch (IOException)
        {
            Interface.Error("Bunker name cannot be null!");
        }
    }
    
    public static void OpenFile()
    {
        
    }

    public static void CreateFile(string fileName, string fileExtension = "txt")
    {
        if (fileExtension.Contains('.'))
        {
            fileExtension = fileExtension.Remove(0, 1);
        }
        string filePath = Environment.CurrentDirectory + @"\" + fileName + "." + fileExtension;
        
        try
        {
            File.Create(filePath);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Interface.Center("File created!");
            Console.WriteLine();
            Thread.Sleep(Delay);
            Console.ResetColor();
        }
        catch (IOException)
        {
            Interface.Error("Something went wrong!");
        }
    }
    
    public static void DeleteFile(string fileName)
    {
        
    }
}
