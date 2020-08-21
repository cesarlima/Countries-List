using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.Extensions.Configuration;

namespace Infra.Remote
{
    public class RemouteCountryRepository : IRemoteCountryRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public RemouteCountryRepository(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public Task<IEnumerable<Country>> GetByAlpha3CodeAsync(string alphaCode)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Country>> GetByCurrencyCodeAsync(string currencyCode)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Country>> GetByNameAsync(string name)
        {
            var baseURL = _configuration.GetSection("restcountries_API_name").Value;
            var response = await _httpClient.GetAsync($"{baseURL}/{name}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var countries = JsonSerializer.Deserialize<IEnumerable<Country>>(content);

            return countries;
        }
    }
}
