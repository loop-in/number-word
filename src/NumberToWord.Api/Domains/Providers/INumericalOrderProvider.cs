using NumberToWord.Api.Domains.Entities;

namespace NumberToWord.Api.Domains.Providers;

public interface INumericalOrderProvider
{
    IEnumerable<NumericalOrder>? GetAll();
}
