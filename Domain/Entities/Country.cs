using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Country
    {
        public string Name { get; set; }
        public string Alpha3Code { get; set; }
        public string Capital { get; set; }
        public string Flag { get; set; }
        public int Population { get; set; }
        public List<string> Borders { get; set; }
        public List<string> TimeZones { get; set; }
        public List<RegionalBloc> RegionalBlocs { get; set; }
        public List<Currency> Currencies { get; set; }
        public List<Language> Languages { get; set; }


        public IEnumerable<string> GetCurrenciesCodes()
        {
            if (Currencies == null)
                return new List<string>();

            return Currencies.Select(c => c.Code);
        }

        public IEnumerable<string> GetRegionalBlocsNames()
        {
            if (RegionalBlocs == null)
                return new List<string>();

            return RegionalBlocs.Select(c => c.Name);
        }
    } 
}
