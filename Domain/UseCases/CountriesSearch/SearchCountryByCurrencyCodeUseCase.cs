using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Repositories;

namespace Domain.UseCases.CountriesSearch
{
    public sealed class SearchCountryByCurrencyCodeUseCase : SearchCountryUseCase
    {
        public SearchCountryByCurrencyCodeUseCase(ILocalCountryRepository localCountryRepository, IRemoteCountryRepository remoteCountryRepository) :
            base(localCountryRepository, remoteCountryRepository)
        { }

        public override async Task<IEnumerable<CountrySearchOutput>> ExecuteAsync(string input)
        {
            var countries = _localCountryRepository.GetBySearchedWord(input, Entities.SearchType.Currency);

            if (HasCountries(countries) == false)
            {
                countries = await _remoteCountryRepository.GetByCurrencyCodeAsync(input);
                await _localCountryRepository.SaveAsync(countries, input, Entities.SearchType.Currency);
            }

            var countriesOutput = CreateCountriesSearchOutputs(countries);

            return countriesOutput;
        }
    }
}
