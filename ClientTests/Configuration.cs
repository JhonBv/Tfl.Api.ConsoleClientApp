using Microsoft.Extensions.DependencyInjection;
using Tfl.API.ConsoleClientApp.Factories;
using Tfl.API.ConsoleClientApp.Interfaces;
using Tfl.API.ConsoleClientApp.Services;

namespace Tfl.API.ConsoleClientApp.Tests
{
    public class Configuration
    {
        public ServiceCollection services;
        public Configuration()
        {
            services = new ServiceCollection();
            ConfigureDi();
        }

        public ServiceCollection returnServiceCollection()
        {
            return services;
        }

        public void ConfigureDi()
        {
            //var services = new ServiceCollection();
            services.AddSingleton<IHttpClientFactoryService, HttpClientFactoryService>();
            services.AddSingleton<IJObjectFactory, JObjectFactory>();
            services.AddSingleton<IResponseFactory, ResponseFactory>();
            services.AddSingleton<IRequestValidator, RequestValidatorService>();
            services.AddTransient<ITflClientService, TflClientService>();
        }
    }
}
