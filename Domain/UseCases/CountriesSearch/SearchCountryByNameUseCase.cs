﻿using System;
using System.Collections.Generic;
using Domain.Repositories;

namespace Domain.UseCases.CountriesSearch
{
    public sealed class SearchCountryByNameUseCase : SearchCountryUseCase
    {
        private readonly ICountryRepository _countryRepository;

        public SearchCountryByNameUseCase(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
        }

        public override IEnumerable<CountrySearchOutput> Execute(string input)
        {
            var countries = _countryRepository.GetByName(input);
            var countriesOutput = CreateCountriesSearchOutputs(countries);

            return countriesOutput;
        }
    }
}
