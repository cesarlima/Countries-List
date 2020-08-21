using System;
using System.Collections.Generic;
using Domain.Repositories;

namespace Domain.UseCases.CountriesSearch
{
    public sealed class SearchCountryByAlpha3CodeUseCase : SearchCountryUseCase
    {
        private readonly ICountryRepository _countryRepository;

        public SearchCountryByAlpha3CodeUseCase(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
        }

        public override IEnumerable<CountrySearchOutput> Execute(string input)
        {
            var countries = _countryRepository.GetByAlphaCode3(input);
            var countriesOutput = CreateCountriesSearchOutputs(countries);

            return countriesOutput;
        }
    }
}
