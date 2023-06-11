using FileContentCounter.Entities;

namespace FileContentCounter.Tests;

[TestFixture]
public class TextDocumentTests
{
    private string _testFilesDirectory;

    [SetUp]
    public void SetUp()
    {
        _testFilesDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestFiles");
    }

    [Test]
    public void CountOccurrences_ValidFile_ReturnsCorrectCount()
    {
        // Arrange
        var filePath = Path.Combine(_testFilesDirectory, "match.txt");
        var textDocument = new TextDocument(filePath);
        const int expectedCount = 3;

        // Act
        var actualCount = textDocument.CountFileNameOccurrencesInContent();
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actualCount, Is.EqualTo(expectedCount));
            Assert.That(textDocument.FileName, Is.EqualTo("match"));
        });
    }

    [Test]
    public void CountOccurrences_WhenFileDoesNotContainMatchingLines_ReturnsZero()
    {
        // Arrange
        var filePath = Path.Combine(_testFilesDirectory, "nomatch.txt");
        var textDocument = new TextDocument(filePath);
        const int expectedCount = 0;

        // Act
        var actualCount = textDocument.CountFileNameOccurrencesInContent();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actualCount, Is.EqualTo(expectedCount));
            Assert.That(textDocument.FileName, Is.EqualTo("nomatch"));
        });
    }
    
    [Test]
    public void CountOccurrences_EmptyFile_ReturnsZeroCount()
    {
        // Arrange
        var filePath = Path.Combine(_testFilesDirectory, "empty.txt");
        var textDocument = new TextDocument(filePath);
        const int expectedCount = 0;

        // Act
        var actualCount = textDocument.CountFileNameOccurrencesInContent();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actualCount, Is.EqualTo(expectedCount));
            Assert.That(textDocument.FileName, Is.EqualTo("empty"));
        });
    }
    
    [Test]
    public void CountOccurrences_WhenFileDoesntExists_ThrowsArgumentException()
    {
        // Arrange
        var filePath = Path.Combine(_testFilesDirectory, "nonexistentfile.txt");

        // Act and Assert
        Assert.Throws<FileNotFoundException>(() =>
        {
            var textDocument = new TextDocument(filePath);
            Assert.Throws<FileNotFoundException>(() => textDocument.CountFileNameOccurrencesInContent());
        });
    }
    
    [Test]
    public void CountOccurrences_WhenWrongFileFormat_ThrowsFileLoadException()
    {
        // Arrange
        var filePath = Path.Combine(_testFilesDirectory, "test.pdf");

        // Act and Assert
        Assert.Throws<FileLoadException>(() =>
        {
            var textDocument = new TextDocument(filePath);
        });
    }
}