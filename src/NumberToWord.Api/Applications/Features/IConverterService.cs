namespace NumberToWord.Api.Applications.Features;

public interface IConverterService
{
    BaseResponse<string> MoneyToWord(string value);
}
