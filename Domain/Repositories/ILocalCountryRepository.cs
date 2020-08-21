using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ILocalCountryRepository
    {
        IEnumerable<Country> GetByName(string name);
        IEnumerable<Country> GetByAlpha3Code(string alphaCode);
        IEnumerable<Country> GetByCurrencyCode(string currencyCode);
        Task SaveAsync(IEnumerable<Country> countries);
    }
}
