using NumberToWord.Api.Common;
using NumberToWord.Api.Domains.Entities;
using NumberToWord.Api.Domains.Providers;

namespace NumberToWord.Api.Providers.Jsons;

public class NumberBasicWordProvider : INumberBasicWordProvider
{
    public IEnumerable<NumberBasicWord>? GetAll()
    {
        return JsonReader<List<NumberBasicWord>>.GetObject("Settings" + Path.DirectorySeparatorChar + "NumberBasicWord.json");
    }
}
