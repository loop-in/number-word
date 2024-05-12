using NumberToWord.Api.Applications.Utils;
using NumberToWord.Api.Domains.Entities;
using NumberToWord.Api.Domains.Providers;

namespace NumberToWord.Api.Applications.Features;

public class ConverterService(
    IFormatValidator formatValidator,
    IMoneySettingsProvider moneySettingsProvider,
    INumberBasicWordProvider numberBasicWordProvider,
    INumericalOrderProvider numericalOrderProvider)
    : IConverterService
{
    public BaseResponse<string> MoneyToWord(string value)
    {
        var response = new BaseResponse<string>();
        if (formatValidator.IsMoney(value))
        {
            var settings = moneySettingsProvider.Get();

            response.Data = ProcessMoney(settings!, value);
            response.Success = true;
            return response;
        }

        response.Error = "Invalid Format";
        return response;
    }

    private string ProcessMoney(MoneySettings settings, string value)
    {
        var parts = value.Split(".");
        
        // Split to 2 parts, convert dollar and cent separately
        string result = string.Empty;
        if (parts.Length == 2)
        {
            result = ConvertCent(settings, parts[1]);
        }

        string currency = string.Empty;
        // Cents are available but dollar is 0, skip convert dollar
        if (!(!string.IsNullOrEmpty(result) && parts[0] == "0"))
        {
            currency = ConvertCurrency(settings, parts[0]);
        }

        result = currency +
            (string.IsNullOrEmpty(currency) || string.IsNullOrEmpty(result) ? string.Empty : " AND ") +
            result;

        return result;
    }

    private string ConvertCurrency(MoneySettings settings, string value)
    {
        var numericalOrders = numericalOrderProvider.GetAll();
        var sortedNumericalOrders = numericalOrders!.OrderBy(x => x.Sequence).ToList();

        var result = ProcessCurrency(value, sortedNumericalOrders, true);
        var suffix = settings.Currency + (value != "1" ? settings.Plural : string.Empty);
        return result + (string.IsNullOrEmpty(result) ? string.Empty : $" {suffix}");
    }

    private string ProcessCurrency(string value, List<NumericalOrder> orders, bool isFirstLevel)
    {
        string result = string.Empty;
        string order = string.Empty;
        var numberGroups = SplitByNumericalOrder(value, orders);
        foreach (var numberGroup in numberGroups)
        {
            string word = string.Empty;
            if (numberGroup.Value.Length > 2)
            {
                word = ProcessCurrency(numberGroup.Value, orders, false);
            }
            else if ((numberGroup.Value != "0" && numberGroups!.Count > 1) ||
                (numberGroups!.Count == 1))
            {
                word = GetBasicWord(numberGroup.Value);
            }

            if (!string.IsNullOrEmpty(word))
            {
                result =
                    (string.IsNullOrEmpty(order) && numberGroups!.Count > 1 && isFirstLevel ? "AND " : string.Empty) +
                    word +
                    (string.IsNullOrEmpty(order) ? string.Empty : " ") + order +
                    (string.IsNullOrEmpty(result) ? string.Empty : " ") + result;
            }
            
            order = numberGroup.Key;
        }

        return result;
    }

    private Dictionary<string, string> SplitByNumericalOrder(string value, List<NumericalOrder> orders)
    {
        var numberGroups = new Dictionary<string, string>();
        int currentOrderIndex = 0;
        int currentSize;
        for (int i = value.Length - 1; i >= 0; i -= currentSize)
        {
            currentSize = orders[currentOrderIndex].TotalDigit;
            int startIndex = Math.Max(i - currentSize + 1, 0);
            int length = i - startIndex + 1;
            string numberGroup = value.Substring(startIndex, length);
            numberGroups.Add(orders[currentOrderIndex].Word, numberGroup);

            currentOrderIndex++;
        }

        return numberGroups;
    }

    private string ConvertCent(MoneySettings settings, string value)
    {
        var cents = value.Length == 1 ? value + "0" : value;
        var word = GetBasicWord(cents);
        
        var suffix = settings.Cent + (cents != "01" ? settings.Plural : string.Empty);
        return word + " " + suffix;
    }

    private string GetBasicWord(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return string.Empty;
        }

        var basicWords = numberBasicWordProvider.GetAll();

        var basicWord = basicWords!.FirstOrDefault(w => w.Number == value);
        if (basicWord is not null)
        {
            return basicWord.Word;
        }

        string firstDigit = string.Empty;
        if (value[0] != '0')
        {
            var firstBasicWord = basicWords!.FirstOrDefault(w => w.Number == value[0] + "0");
            firstDigit = firstBasicWord is not null ? firstBasicWord.Word : string.Empty;
        }
        
        string secondDigit = string.Empty;
        if (value[1] != '0' && value.Length > 1)
        {
            var secondBasicWord = basicWords!.FirstOrDefault(w => w.Number == value[1].ToString());
            secondDigit = secondBasicWord is not null ? secondBasicWord.Word : string.Empty;
        }
        
        var separator = firstDigit == string.Empty || secondDigit == string.Empty ? string.Empty : "-";
        return firstDigit + separator + secondDigit;
    }
}
