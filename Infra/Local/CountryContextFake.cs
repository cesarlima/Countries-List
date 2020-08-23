using System.Collections.Generic;
using Domain.Entities;

namespace Infra.Local
{
    public sealed class CountryContextFake
    {
        public Dictionary<string, IEnumerable<Country>> CountrySearchies { get; } = new Dictionary<string, IEnumerable<Country>>();
        public List<Country> Countries { get; } = new List<Country>();
    }
}
