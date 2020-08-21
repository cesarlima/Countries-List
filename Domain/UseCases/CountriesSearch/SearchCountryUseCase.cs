using System.Collections.Generic;
using Domain.Repositories;

namespace Domain.UseCases.CountriesSearch
{
    public class SearchCountryByNameUseCase
    {
        private readonly ICountryRepository _countryRepository;

        public IEnumerable<CountrySearchOutput> Execute(string name)
        {
            var countries = _countryRepository.GetByName(name);

            if (countries == null)
                return null;

            var countriesOutput = new List<CountrySearchOutput>();

            foreach (var country in countries)
            {
                var currencies = country.GetCurrenciesCodes();
                var regionalBolcs = country.GetRegionalBlocsNames();
                var countryOutput = new CountrySearchOutput(country.Name, country.Alpha3Code, country.Flag, currencies, regionalBolcs);
                countriesOutput.Add(countryOutput);
            }

            return countriesOutput;
        }
    }
}
