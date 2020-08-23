using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;

namespace Domain.UseCases.CountrySearch
{
    public class SearchCountryByIdUseCase
    {
        protected readonly ILocalCountryRepository _localCountryRepository;

        public SearchCountryByIdUseCase(ILocalCountryRepository localCountryRepository)
        {
            _localCountryRepository = localCountryRepository ?? throw new ArgumentNullException(nameof(localCountryRepository));
        }

        public async Task<Country> ExecuteAsync(Guid id)
        {
            var country = await _localCountryRepository.GetByIdAsync(id);
            return country;
        }
    }
}
