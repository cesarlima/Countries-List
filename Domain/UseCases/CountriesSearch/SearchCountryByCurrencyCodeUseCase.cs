using System;
using System.Collections.Generic;
using Domain.Repositories;

namespace Domain.UseCases.CountriesSearch
{
    public sealed class SearchCountryByCurrencyCodeUseCase : SearchCountryUseCase
    {
        private readonly ICountryRepository _countryRepository;

        public SearchCountryByCurrencyCodeUseCase(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
        }

        public override IEnumerable<CountrySearchOutput> Execute(string input)
        {
            var countries = _countryRepository.GetByCurrencyCode(input);
            var countriesOutput = CreateCountriesSearchOutputs(countries);

            return countriesOutput;
        }
    }
}
