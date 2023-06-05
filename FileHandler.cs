using System.Diagnostics;
using CliWrap;

namespace BlackRock;

public static class FileHandler
{
    public static void OpenDirectory(string directory = "")
    {
        Environment.CurrentDirectory = Environment.CurrentDirectory + @"\" + directory;
        string[] files = Directory.GetFileSystemEntries(Environment.CurrentDirectory);

        string root = Program.Root();
        if (files.Length == 0)
        {
            Console.WriteLine();
            Interface.Center(Environment.CurrentDirectory == root 
                ? "You don't have any bunkers yet." 
                : "You don't have any files yet.");
            Console.WriteLine();
        }
        else 
        {
            int initialIndex = Environment.CurrentDirectory.Length + 1;
            
            Console.WriteLine();
            foreach (string file in files)
            {
                Console.WriteLine(file[(initialIndex)..]);
            }
            Console.WriteLine();
        }
    }

    public static void CreateDirectory(string directory)
    {
        try
        {
            Directory.CreateDirectory(Environment.CurrentDirectory + @"\" + directory);
            Interface.Success("Bunker created!");
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
            Interface.Success("Bunker deleted!");
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
    
    public static void OpenFile(string fileName="")
    {
        if (fileName != "")
        {
            try
            {
                Cli.Wrap("code").WithArguments(@".\" + fileName).ExecuteAsync();
            }
            catch (Exception)
            {
                Interface.Error("Something went wrong while trying to open the file!");
            }
        }
        else
        {
            Interface.Error("File name cannot be blank!");
        }
    }

    public static void CreateFile(string fileName, string fileExtension = "")
    {
        string filePath; 
            
        if (fileExtension.Contains('.'))
        {
            fileExtension = fileExtension.Remove(0, 1);
        }

        if (fileExtension == "")
        {
            filePath = Environment.CurrentDirectory + @"\" + fileName + ".txt";
        }
        else
        {
            filePath = Environment.CurrentDirectory + @"\" + fileName + "." + fileExtension;
        }
        
        Console.WriteLine(filePath); Thread.Sleep(2000);
        
        try
        {
            File.Create(filePath);
            Interface.Success("File created!");
        }
        catch (IOException)
        {
            Interface.Error("Something went wrong!");
        }
    }
    
    public static void DeleteFile(string fileName)
    {
        string filePath = Environment.CurrentDirectory + fileName;

        if (File.Exists(filePath))
        {
           File.Delete(filePath); 
           Interface.Success("File deleted!");
        }
        else
        {
            Interface.Error("The file you're trying to delete doesn't exist!");
        }
    }
}
