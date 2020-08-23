using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;

namespace Domain.UseCases.CountriesSearch
{
    public abstract class SearchCountryUseCase
    {
        protected readonly ILocalCountryRepository _localCountryRepository;
        protected readonly IRemoteCountryRepository _remoteCountryRepository;

        protected SearchCountryUseCase(ILocalCountryRepository localCountryRepository, IRemoteCountryRepository remoteCountryRepository)
        {
            _localCountryRepository = localCountryRepository ?? throw new ArgumentNullException(nameof(localCountryRepository));
            _remoteCountryRepository = remoteCountryRepository ?? throw new ArgumentNullException(nameof(remoteCountryRepository));
        }

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
                var countryOutput = new CountrySearchOutput(country.Id, country.Name, country.Alpha3Code, country.Flag, currencies, regionalBolcs);
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
