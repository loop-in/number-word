using NumberToWord.Api.Domains.Entities;

namespace NumberToWord.Api.Domains.Providers;

public interface INumberBasicWordProvider
{
    IEnumerable<NumberBasicWord>? GetAll();
}
