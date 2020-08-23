using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Repositories;

namespace Domain.UseCases.CountriesSearch
{
    public sealed class SearchCountryByNameUseCase : SearchCountryUseCase
    {
        public SearchCountryByNameUseCase(ILocalCountryRepository localCountryRepository, IRemoteCountryRepository remoteCountryRepository) :
            base(localCountryRepository, remoteCountryRepository)
        { }
        
        public override async Task<IEnumerable<CountrySearchOutput>> ExecuteAsync(string input)
        {
            var countries = _localCountryRepository.GetBySearchedWord(input, Entities.SearchType.Name);

            if (HasCountries(countries) == false)
            {
                countries = await _remoteCountryRepository.GetByNameAsync(input);
                await _localCountryRepository.SaveAsync(countries, input, Entities.SearchType.Name);
            }

            var countriesOutput = CreateCountriesSearchOutputs(countries);

            return countriesOutput;
        }
    }
}
