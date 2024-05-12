using NumberToWord.Api.Applications.Features;
using NumberToWord.Api.Applications.Utils;

namespace NumberToWord.Api.Applications;

public static class DependencyInjection
{
    public static void AddApplications(this IServiceCollection services)
    {
        services.AddScoped<IConverterService, ConverterService>();
        services.AddScoped<IFormatValidator, FormatValidator>();
    }
}
