namespace FileContentCounter.Services;

public interface IFileService
{
    int CountWordOccurrencesInFile(string filePath, out string fileName);
}