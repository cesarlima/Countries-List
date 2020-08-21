using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetByName(string name);
        IEnumerable<Country> GetByAlphaCode(string alphaCode);
        IEnumerable<Country> GetByCurrencyCode(string currencyCode);
    }
}
