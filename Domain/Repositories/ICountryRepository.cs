using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetByName(string name);
        IEnumerable<Country> GetByAlpha3Code(string alphaCode);
        IEnumerable<Country> GetByCurrencyCode(string currencyCode);
    }
}
