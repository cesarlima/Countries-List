using Infra.Remote;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.ConfigExtensions
{
    public static class DependencyConfigurations
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<RemoteCountryRepository>();
            services.AddSingleton<Infra.Local.CountryContextFake>();
            services.AddScoped<Domain.Repositories.ILocalCountryRepository, Infra.Local.LocalCountryRepository>();
            services.AddScoped<Domain.Repositories.IRemoteCountryRepository>(x => x.GetRequiredService<RemoteCountryRepository>());

            services.AddScoped<Domain.UseCases.CountriesSearch.SearchCountryByNameUseCase>();
            services.AddScoped<Domain.UseCases.CountriesSearch.SearchCountryByAlpha3CodeUseCase>();
            services.AddScoped<Domain.UseCases.CountriesSearch.SearchCountryByCurrencyCodeUseCase>();
            services.AddScoped<Domain.UseCases.CountrySearch.SearchCountryByIdUseCase>();
        }
    }
}
