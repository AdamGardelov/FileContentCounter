using FileContentCounter.Services;

namespace FileContentCounter.Tests;

[TestFixture]
public class FileServiceTests
{
    private FileService fileService;
    private string testFilesDirectory;
    
    //TODO: Test files are in use when running tests.. fix this somehow
    
    [SetUp]
    public void SetUp()
    {
        fileService = new FileService();
        testFilesDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles");
    }

    [Test]
    public void CountOccurrences_ValidFile_ReturnsCorrectCount()
    {
        // Arrange
        var filePath = $"{testFilesDirectory}\\match.txt";
        const int expectedCount = 3;

        // Act
        var actualCount = fileService.CountWordOccurrencesInFile(filePath, out var fileName);
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actualCount, Is.EqualTo(expectedCount));
            Assert.That(fileName, Is.EqualTo("match"));
        });
    }

    [Test]
    public void CountOccurrences_WhenFileDoesNotContainMatchingLines_ReturnsZero()
    {
        // Arrange
        var filePath = $"{testFilesDirectory}\\nomatch.txt";
        const int expectedCount = 0;

        // Act
        var actualCount = fileService.CountWordOccurrencesInFile(filePath, out var fileName);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actualCount, Is.EqualTo(expectedCount));
            Assert.That(fileName, Is.EqualTo("nomatch"));
        });
    }
    
    [Test]
    public void CountOccurrences_EmptyFile_ReturnsZeroCount()
    {
        // Arrange
        var filePath = $"{testFilesDirectory}\\empty.txt";
        const int expectedCount = 0;

        // Act
        var actualCount = fileService.CountWordOccurrencesInFile(filePath, out var fileName);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actualCount, Is.EqualTo(expectedCount));
            Assert.That(fileName, Is.EqualTo("empty"));
        });
    }
    
    [Test]
    public void CountOccurrences_WhenFileDoesntExists_ThrowsArgumentException()
    {
        // Arrange
        var filePath = $"{testFilesDirectory}\\nonexistentfile.txt";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => fileService.CountWordOccurrencesInFile(filePath, out _));
    }
}