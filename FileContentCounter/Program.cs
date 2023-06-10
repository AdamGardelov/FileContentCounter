using FileContentCounter.Exceptions;
using FileContentCounter.Services;

namespace FileContentCounter;

class Program
{
    static void Main(string[] args)
    {
        IFileService fileService = new FileService();
        
        if (args.Length != 1)
        {
            Console.WriteLine("Please provide a valid path.");
            return;
        }
        
        var filePath = args[0];
        
        try
        {
            var occurrences = fileService.CountWordOccurrencesInFile(filePath, out var fileName);
            Console.WriteLine($"The filename '{fileName}' occurs {occurrences} times in the file.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Invalid filepath: {ex.Message}");
        }
        catch (FileProcessingException ex)
        {
            Console.WriteLine($"Error occurred while processing the file: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}