namespace FileContentCounter.Entities;

public class TextDocument
{
    private static readonly string[] TextExtensions = { ".txt", ".doc", ".docx", ".rtf" };
    private string FilePath { get; }
    public string FileName { get; }

    /// <summary>
    /// Represents a text document that can be processed and analyzed.
    /// </summary>
    /// <remarks>
    /// The TextDocument class provides functionality to count the occurrences of a specific word within the content of the document.
    /// It also verifies if the given file path is valid and checks if the file is a supported text document format (.txt, .doc, .docx, .rtf).
    /// </remarks>
    public TextDocument(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("Not a valid filepath.");
        }
        
        if (!IsTextDocument(filePath))
        {
            throw new FileLoadException("Not a valid text document.");
        }

        FilePath = filePath;
        FileName = Path.GetFileNameWithoutExtension(FilePath);
    }

    /// <summary>
    /// Counts the occurrences of a specific word in this file.
    /// </summary>
    /// <returns>The total count of occurrences of the word in the file.</returns>
    /// <exception cref="FileProcessingException">Thrown when an error occurs during file processing.</exception>
    public int CountFileNameOccurrencesInContent()
    {
        if (string.IsNullOrEmpty(FileName))
        {
            throw new InvalidOperationException("Filename is empty.");
        }
        
        try
        {
            using var fileStream = File.Open(FilePath, FileMode.Open);
            using var fileReader = new StreamReader(fileStream);

            var count = 0;
            string line;
            
            while ((line = fileReader.ReadLine()) != null)
            {
                count += CountWordOccurrencesInLine(line);
            }

            return count;
        }
        catch (Exception ex)
        {
            throw new FileProcessingException("Error occurred while processing the file.", ex);
        }
    }

    #region Private help methods

    private static bool IsTextDocument(string filePath)
    {
        var extension = Path.GetExtension(filePath);
        return TextExtensions.Contains(extension);
    }
    
    private int CountWordOccurrencesInLine(string line)
    {
        var count = 0;
        var index = 0;

        while (true)
        {
            index = line.IndexOf(FileName, index);
            if (index == -1)
            {
                break;
            }

            count++;
            index += FileName.Length;
        }

        return count;
    }

    #endregion
}