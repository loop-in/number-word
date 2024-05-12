using Moq;
using NumberToWord.Api.Applications.Features;
using NumberToWord.Api.Applications.Utils;
using NumberToWord.Api.Common;
using NumberToWord.Api.Domains.Entities;
using NumberToWord.Api.Domains.Providers;

namespace NumberToWord.Test.Applications.Features;

public class ConverterServiceTest
{
    private Mock<IFormatValidator> _formatValidatorStub;
    private Mock<IMoneySettingsProvider> _settingsProviderStub;
    private Mock<INumberBasicWordProvider> _numberBasicWordProviderStub;
    private Mock<INumericalOrderProvider> _numericalOrderProviderStub;

    [SetUp]
    public void Setup()
    {
        _formatValidatorStub = new Mock<IFormatValidator>();

        _settingsProviderStub = new Mock<IMoneySettingsProvider>();
        _settingsProviderStub
            .Setup(f => f.Get())
            .Returns(new MoneySettings()
            {
                Cent = "CENT",
                Currency = "DOLLAR",
                Plural = "S",
            });

        _numberBasicWordProviderStub = new Mock<INumberBasicWordProvider>();
        _numberBasicWordProviderStub
            .Setup(f => f.GetAll())
            .Returns(JsonReader<IEnumerable<NumberBasicWord>>.GetObject("Settings" + Path.DirectorySeparatorChar + "NumberBasicWord.json"));
        
        _numericalOrderProviderStub = new Mock<INumericalOrderProvider>();
        _numericalOrderProviderStub
            .Setup(f => f.GetAll())
            .Returns(JsonReader<IEnumerable<NumericalOrder>>.GetObject("Settings" + Path.DirectorySeparatorChar + "NumericalOrder.json"));
    }

    [Test]
    [TestCase("0", "ZERO DOLLARS")]
    [TestCase("0.80", "EIGHTY CENTS")]
    [TestCase("888", "EIGHT HUNDRED AND EIGHTY-EIGHT DOLLARS")]
    [TestCase("123.9", "ONE HUNDRED AND TWENTY-THREE DOLLARS AND NINETY CENTS")]
    [TestCase("567.45", "FIVE HUNDRED AND SIXTY-SEVEN DOLLARS AND FOURTY-FIVE CENTS")]
    [TestCase("700450.90", "SEVEN HUNDRED THOUSAND FOUR HUNDRED AND FIFTY DOLLARS AND NINETY CENTS")]
    [TestCase("2300880", "TWO MILLION THREE HUNDRED THOUSAND EIGHT HUNDRED AND EIGHTY DOLLARS")]
    public void MoneyToWord_ValidFormat_ReturnCorrectWord(string value, string result)
    {
        // Arrange
        _formatValidatorStub
            .Setup(f => f.IsMoney(It.IsAny<string>()))
            .Returns(true);
        var service = new ConverterService(
            _formatValidatorStub.Object,
            _settingsProviderStub.Object,
            _numberBasicWordProviderStub.Object,
            _numericalOrderProviderStub.Object);

        // Act
        var actual = service.MoneyToWord(value);

        // Assert
        Assert.That(actual, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(actual.Data, Is.EqualTo(result));
            Assert.That(actual.Success, Is.True);
        });
    }

    [Test]
    [TestCase("ABC")]
    [TestCase("00.09")]
    [TestCase("0555")]
    [TestCase("100.AA")]
    public void MoneyToWord_InvalidFormat_ReturnError(string value)
    {
        // Arrange
        _formatValidatorStub
            .Setup(f => f.IsMoney(It.IsAny<string>()))
            .Returns(false);
        var service = new ConverterService(
            _formatValidatorStub.Object,
            _settingsProviderStub.Object,
            _numberBasicWordProviderStub.Object,
            _numericalOrderProviderStub.Object);

        // Act
        var actual = service.MoneyToWord(value);

        // Assert
        Assert.That(actual, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(actual.Data, Is.Null);
            Assert.That(actual.Error, Is.Not.Empty);
            Assert.That(actual.Success, Is.False);
        });
    }
}