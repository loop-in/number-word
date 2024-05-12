using NumberToWord.Api.Common;
using NumberToWord.Api.Domains.Entities;
using NumberToWord.Api.Domains.Providers;

namespace NumberToWord.Api.Providers.Jsons;

public class MoneySettingsProvider : IMoneySettingsProvider
{
    public MoneySettings? Get()
    {
        var results = JsonReader<List<MoneySettings>>.GetObject("Settings" + Path.DirectorySeparatorChar + "MoneySettings.json");
        return results?.FirstOrDefault();
    }
}
