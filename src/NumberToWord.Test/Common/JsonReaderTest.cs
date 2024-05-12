using NumberToWord.Api.Common;
using NumberToWord.Api.Domains.Entities;

namespace NumberToWord.Test.Common;

public class JsonReaderTest
{
    [Test]
    public void GetObject_ValidObject_ReturnObject()
    {
        // Arrange
        string filePath = "Settings" + Path.DirectorySeparatorChar + "MoneySettings.json";

        // Act
        var actual = JsonReader<List<MoneySettings>>.GetObject(filePath);

        // Assert
        Assert.That(actual, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(actual, Has.Count.EqualTo(1));
            Assert.That(actual[0].Cent, Is.EqualTo("CENT"));
            Assert.That(actual[0].Currency, Is.EqualTo("DOLLAR"));
        });
    }

    [Test]
    public void GetObject_InvalidObject_ReturnNull()
    {
        // Arrange
        string filePath = "Settings" + Path.DirectorySeparatorChar + "MoneySettings.json";

        // Act
        var actual = JsonReader<MoneySettings>.GetObject(filePath);

        // Assert
        Assert.That(actual, Is.Null);
    }
}