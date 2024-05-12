using NumberToWord.Api.Domains.Entities;

namespace NumberToWord.Api.Domains.Providers;

public interface IMoneySettingsProvider
{
    MoneySettings? Get();
}
