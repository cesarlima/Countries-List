using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Repositories;

namespace Domain.UseCases.CountriesSearch
{
    public sealed class SearchCountryByAlpha3CodeUseCase : SearchCountryUseCase
    {
        public SearchCountryByAlpha3CodeUseCase(ILocalCountryRepository localCountryRepository, IRemoteCountryRepository remoteCountryRepository) :
            base(localCountryRepository, remoteCountryRepository)
        { }

        public override async Task<IEnumerable<CountrySearchOutput>> ExecuteAsync(string input)
        {
            var countries = _localCountryRepository.GetBySearchedWord(input, Entities.SearchType.Code);

            if (HasCountries(countries) == false)
            {
                countries = await _remoteCountryRepository.GetByAlpha3CodeAsync(input);
                await _localCountryRepository.SaveAsync(countries, input, Entities.SearchType.Code);
            }

            var countriesOutput = CreateCountriesSearchOutputs(countries);

            return countriesOutput;
        }
    }
}
