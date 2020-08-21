using System.Collections.Generic;
using Domain.Entities;

namespace Domain.UseCases.CountriesSearch
{
    public abstract class SearchCountryUseCase
    {
        public abstract IEnumerable<CountrySearchOutput> Execute(string name);
        
        protected IEnumerable<CountrySearchOutput> CreateCountriesSearchOutputs(IEnumerable<Country> countries)
        {
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
