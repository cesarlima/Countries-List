using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.Extensions.Configuration;

namespace Infra.Remote
{
    public class RemoteCountryRepository : IRemoteCountryRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public RemoteCountryRepository(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Country>> GetByAlpha3CodeAsync(string alphaCode)
        {
            var endpontURL = _configuration.GetSection("Restcountries_URLs:AlphaCode").Value;
            var countries = await GetCountries($"{endpontURL}/{alphaCode}");
            return countries;
        }

        public async Task<IEnumerable<Country>> GetByCurrencyCodeAsync(string currencyCode)
        {
            var endpontURL = _configuration.GetSection("Restcountries_URLs:Currency").Value;
            var countries = await GetCountries($"{endpontURL}/{currencyCode}");
            return countries;
        }

        public async Task<IEnumerable<Country>> GetByNameAsync(string name)
        {
            var endpontURL = _configuration.GetSection("Restcountries_URLs:Name").Value;
            var countries = await GetCountries($"{endpontURL}/{name}");
            return countries;
        }

        private async Task<IEnumerable<Country>> GetCountries(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var countries = JsonSerializer.Deserialize<IEnumerable<Country>>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return countries;
        }
    }
}
