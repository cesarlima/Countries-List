using System;
using System.Collections.Generic;

namespace Domain.UseCases.CountriesSearch
{
    public sealed class CountrySearchOutput
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Alpha3Code { get; }
        public string Flag { get; }
        public IEnumerable<string> Currencies { get; }
        public IEnumerable<string> RegionalBlocs { get; }

        public CountrySearchOutput(Guid id, string name, string alpha3Code, string flag, IEnumerable<string> currencies, IEnumerable<string> regionalBlocs)
        {
            Id = id;
            Name = name;
            Alpha3Code = alpha3Code;
            Flag = flag;
            Currencies = currencies;
            RegionalBlocs = regionalBlocs;
        }
    }
}
