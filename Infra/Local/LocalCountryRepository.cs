using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;

namespace Infra.Local
{
    public class LocalCountryRepository : ILocalCountryRepository
    {
        public LocalCountryRepository()
        {
        }

        public IEnumerable<Country> GetByAlpha3Code(string alphaCode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Country> GetByCurrencyCode(string currencyCode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Country> GetByName(string name)
        {
            return null;
        }

        public Task SaveAsync(IEnumerable<Country> countries)
        {
            throw new NotImplementedException();
        }
    }
}
