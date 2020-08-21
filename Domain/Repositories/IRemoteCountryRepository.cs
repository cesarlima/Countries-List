using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IRemoteCountryRepository
    {
        Task<IEnumerable<Country>> GetByNameAsync(string name);
        Task<IEnumerable<Country>> GetByAlpha3CodeAsync(string alphaCode);
        Task<IEnumerable<Country>> GetByCurrencyCodeAsync(string currencyCode);
    }
}
