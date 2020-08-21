using System.Collections.Generic;

namespace Domain.UseCases.CountriesSearch
{
    public sealed class CountrySearchOutput
    {
        public string Name { get; }
        public string Alpha3Code { get; }
        public string Flag { get; }
        public IEnumerable<string> Currencies { get; }
        public IEnumerable<string> RegionalBlocs { get; }

        public CountrySearchOutput(string name, string alpha3Code, string flag, IEnumerable<string> currencies, IEnumerable<string> regionalBlocs)
        {
            Name = name;
            Alpha3Code = alpha3Code;
            Flag = flag;
            Currencies = currencies;
            RegionalBlocs = regionalBlocs;
        }
    }
}
