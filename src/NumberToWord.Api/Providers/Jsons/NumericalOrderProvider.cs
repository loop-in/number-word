using NumberToWord.Api.Common;
using NumberToWord.Api.Domains.Entities;
using NumberToWord.Api.Domains.Providers;

namespace NumberToWord.Api.Providers.Jsons;

public class NumericalOrderProvider : INumericalOrderProvider
{
    public IEnumerable<NumericalOrder>? GetAll()
    {
        return JsonReader<List<NumericalOrder>>.GetObject("Settings" + Path.DirectorySeparatorChar + "NumericalOrder.json");
    }
}
