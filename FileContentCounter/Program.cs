using FileContentCounter.Entities;

namespace FileContentCounter;

internal class Program
{
    private static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Please provide a valid path.");
            return;
        }
        
        var filePath = args[0];
        TextDocument textDocument;

        try
        {
            textDocument = new TextDocument(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred when loading the file: {ex.Message}");
            return;
        }
        
        try
        {
            var occurrences = textDocument.CountFileNameOccurrencesInContent();
            Console.WriteLine($"The filename '{textDocument.FileName}' occurs {occurrences} times in the file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred when processing the file: {ex.Message}");
        }
    }
}