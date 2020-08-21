using System.Collections.Generic;
using Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.UseCases.CountriesSearch
{
    public abstract class SearchCountryUseCase
    {
        public abstract Task<IEnumerable<CountrySearchOutput>> ExecuteAsync(string input);
        
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

        protected bool HasCountries(IEnumerable<Country> countries)
        {
            return countries != null && countries.Count() > 0;
        }
    }
}
