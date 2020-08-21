using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Repositories;

namespace Domain.UseCases.CountriesSearch
{
    public sealed class SearchCountryByNameUseCase : SearchCountryUseCase
    {
        private readonly ILocalCountryRepository _localCountryRepository;
        private readonly IRemoteCountryRepository _remoteCountryRepository;

        public SearchCountryByNameUseCase(ILocalCountryRepository localCountryRepository, IRemoteCountryRepository remoteCountryRepository)
        {
            _localCountryRepository = localCountryRepository ?? throw new ArgumentNullException(nameof(localCountryRepository));
            _remoteCountryRepository = remoteCountryRepository ?? throw new ArgumentNullException(nameof(remoteCountryRepository));
        }

        public override async Task<IEnumerable<CountrySearchOutput>> ExecuteAsync(string input)
        {
            var countries = _localCountryRepository.GetByName(input);

            if (HasCountries(countries) == false)
            {
                countries = await _remoteCountryRepository.GetByNameAsync(input);
                _ = _localCountryRepository.SaveAsync(countries);
            }

            var countriesOutput = CreateCountriesSearchOutputs(countries);

            return countriesOutput;
        }
    }
}
