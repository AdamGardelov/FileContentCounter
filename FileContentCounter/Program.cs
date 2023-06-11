using FileContentCounter.Entities;

namespace FileContentCounter;

internal abstract class Program
{
    private static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Please provide a valid path.");
            return;
        }
        
        var filePath = args[0];
        var textDocument = new TextDocument(filePath);
        
        try
        {
            var occurrences = textDocument.CountFileNameOccurrencesInContent();
            Console.WriteLine($"The filename '{textDocument.FileName}' occurs {occurrences} times in the file.");
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