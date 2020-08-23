using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using System.Linq;

namespace Infra.Local
{
    public class LocalCountryRepository : ILocalCountryRepository
    {
        private readonly CountryContextFake _context;

        public LocalCountryRepository(CountryContextFake context)
        {
            _context = context;
        }

        public Task<Country> GetByIdAsync(Guid id)
        {
            return Task.FromResult(_context.Countries.FirstOrDefault(c => c.Id == id));
        }

        public IEnumerable<Country> GetBySearchedWord(string searchedWord, SearchType searchType)
        {
            var key = $"{searchedWord}-{searchType}";
            return _context.CountrySearchies.ContainsKey(key) ? _context.CountrySearchies[key] : null;
        }

        public async Task SaveAsync(IEnumerable<Country> countries, string searchedWord, SearchType searchType)
        {
            var key = $"{searchedWord}-{searchType}";

            if (_context.CountrySearchies.ContainsKey(key))
                _context.CountrySearchies[key] = countries;
            else
                _context.CountrySearchies.Add(key, countries);

            _context.Countries.AddRange(countries);

            await Task.CompletedTask;
        }
    }
}
