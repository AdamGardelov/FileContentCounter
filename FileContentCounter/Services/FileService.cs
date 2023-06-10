using FileContentCounter.Exceptions;

namespace FileContentCounter.Services;

public class FileService : IFileService
{
    public int CountWordOccurrencesInFile(string filePath, out string fileName)
    {
        if (!Path.Exists(filePath))
        {
            throw new ArgumentException("Not a valid filepath.");
        }

        try
        {
            using var fileStream = File.Open(filePath, FileMode.Open);
            using var fileReader = new StreamReader(fileStream);
        
            fileName = Path.GetFileNameWithoutExtension(filePath);
            var count = 0;

            using var reader = new StreamReader(filePath);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                count += CountWordOccurrencesInLine(line, fileName);
            }

            return count;
        }
        catch (Exception ex)
        {
            throw new FileProcessingException("Error occurred while processing the file.", ex);
        }
    }
    
    private int CountWordOccurrencesInLine(string line, string word)
    {
        var count = 0;
        var index = 0;

        while (true)
        {
            index = line.IndexOf(word, index, StringComparison.OrdinalIgnoreCase);
            if (index == -1)
            {
                break;
            }

            count++;
            index += word.Length;
        }

        return count;
    }
}