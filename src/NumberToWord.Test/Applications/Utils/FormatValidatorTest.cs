using NumberToWord.Api.Applications.Utils;

namespace NumberToWord.Test.Applications.Utils;

public class FormatValidatorTest
{
    [Test]
    [TestCase("0")]
    [TestCase("0.80")]
    [TestCase("888")]
    [TestCase("123.9")]
    [TestCase("567.45")]
    public void IsMoney_ValidFormat_ReturnTrue(string value)
    {
        // Arrange
        var validator = new FormatValidator();

        // Act
        var actual = validator.IsMoney(value);

        // Assert
        Assert.That(actual, Is.True);
    }

    [Test]
    [TestCase("abc")]
    [TestCase("567.")]
    [TestCase("abc.456")]
    [TestCase("12.123.9")]
    [TestCase("567.456")]
    [TestCase("00567.50")]
    public void IsMoney_InvalidFormat_ReturnTrue(string value)
    {
        // Arrange
        var validator = new FormatValidator();

        // Act
        var actual = validator.IsMoney(value);

        // Assert
        Assert.That(actual, Is.False);
    }
}