using FileContentCounter.Exceptions;

namespace FileContentCounter.Services;

public class FileService : IFileService
{
    /// <summary>
    /// Counts the occurrences of a specific word in a file.
    /// </summary>
    /// <param name="filePath">The path to the file.</param>
    /// <param name="fileName">Output parameter that receives the name of the file without extension.</param>
    /// <returns>The total count of occurrences of the word in the file.</returns>
    /// <exception cref="ArgumentException">Thrown when the provided filePath is not valid.</exception>
    /// <exception cref="FileProcessingException">Thrown when an error occurs during file processing.</exception>
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
            
            var count = 0;
            string line;
            fileName = Path.GetFileNameWithoutExtension(filePath);
            
            while ((line = fileReader.ReadLine()) != null)
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

    #region Private help methods

    private int CountWordOccurrencesInLine(string line, string word)
    {
        var count = 0;
        var index = 0;

        while (true)
        {
            index = line.IndexOf(word, index);
            if (index == -1)
            {
                break;
            }

            count++;
            index += word.Length;
        }

        return count;
    }

    #endregion
}