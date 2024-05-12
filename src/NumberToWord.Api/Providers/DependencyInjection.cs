using NumberToWord.Api.Domains.Providers;
using NumberToWord.Api.Providers.Jsons;

namespace NumberToWord.Api.Providers;

public static class DependencyInjection
{
    public static void AddProviders(this IServiceCollection services)
    {
        services.AddScoped<IMoneySettingsProvider, MoneySettingsProvider>();
        services.AddScoped<INumberBasicWordProvider, NumberBasicWordProvider>();
        services.AddScoped<INumericalOrderProvider, NumericalOrderProvider>();
    }
}
