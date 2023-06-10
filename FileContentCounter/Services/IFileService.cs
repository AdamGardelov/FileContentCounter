namespace FileContentCounter.Services;

public interface IFileService
{
    /// <summary>
    /// Counts the occurrences of a specific word in a file.
    /// </summary>
    /// <param name="filePath">The path to the file.</param>
    /// <param name="fileName">Output parameter that receives the name of the file without extension.</param>
    /// <returns>The total count of occurrences of the word in the file.</returns>
    /// <exception cref="ArgumentException">Thrown when the provided filePath is not valid.</exception>
    /// <exception cref="FileProcessingException">Thrown when an error occurs during file processing.</exception>
    int CountWordOccurrencesInFile(string filePath, out string fileName);
}