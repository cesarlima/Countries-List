using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ILocalCountryRepository
    {
        Task<Country> GetByIdAsync(Guid id);
        IEnumerable<Country> GetBySearchedWord(string searchedWord, SearchType searchType);
        Task SaveAsync(IEnumerable<Country> countries, string searchedWord, SearchType searchType);
    }
}
