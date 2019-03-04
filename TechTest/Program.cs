using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Threading.Tasks;
using Tfl.API.ConsoleClientApp.Factories;
using Tfl.API.ConsoleClientApp.Interfaces;
using Tfl.API.ConsoleClientApp.Exceptions;
using Tfl.API.ConsoleClientApp.Services;

namespace TechTest
{
    enum ExitCode : int
    {
        Success = 00,
        InvalidRequest = 01
    }
    class Program
    {
        static IJObjectFactory _factory;
        static IResponseFactory _response;
        static IRequestValidator _validator;
        static string daRoad { get; set; }

        static string returnedJson { get; set; }      
        static void Main(string[] args)
        {
            TflClientService tflClient = new TflClientService(_response);
            _factory = new JObjectFactory();
            _response = new ResponseFactory();
            _validator = new RequestValidatorService(_response,_factory);

            var services = new ServiceCollection();
            //JB. Register TflClientService (httpClient for Tfl)
            services.AddHttpClient<HttpClientFactoryService>();

            var serviceProvider = services.BuildServiceProvider();

            SetUpDi(services);
            SetUpLogging(services, serviceProvider);

            //JB. Begin execution of client and configuration of the App.
            Execute(tflClient, services).Wait();

            Console.ReadKey();
        }
        /// <summary>
        /// Starts the TflClientService and executes the application logic, making sure the correct parameters are passed.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="services"></param>
        /// <returns></returns>
        static async Task Execute(TflClientService service, ServiceCollection services)
        {
            Console.WriteLine("Hello, please type below the road you want to find information:");
            daRoad = Console.ReadLine();
            if (!String.IsNullOrEmpty(daRoad))
            {                
                try
                {
                    Console.WriteLine(_validator.ValidateRequest(await service.InitializeClient(daRoad, services), daRoad));
                    Console.WriteLine((int)ExitCode.Success);
                    return;
                }
                catch (InvalidRoadException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine((int)ExitCode.InvalidRequest);
                    return;
                }
            }

            Console.WriteLine(new NullRoadIdException("").Message);
            Console.WriteLine((int)ExitCode.InvalidRequest);
            return;
        }

        /// <summary>
        /// Setup DI container.
        /// </summary>
        /// <param name="services"></param>
        static void SetUpDi(ServiceCollection services)
        {            
            //DI configuration
            services.AddSingleton<IHttpClientFactoryService, HttpClientFactoryService>();
            services.AddSingleton<IJObjectFactory, JObjectFactory>();
            services.AddSingleton<IResponseFactory, ResponseFactory>();
            services.AddSingleton<IRequestValidator, RequestValidatorService>();
            services.AddTransient<ITflClientService, TflClientService>();            
        }

        /// <summary>
        /// Setup logging so that all events are logged for future reference
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceProvider"></param>
        static void SetUpLogging(ServiceCollection services, ServiceProvider serviceProvider)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();
                        
            services.AddLogging(builder =>
            {   // Add Serilog
                builder.AddSerilog();
             });

            // This is the Microsoft Logging interface (https://merbla.com/2018/04/25/exploring-serilog-v2---using-the-http-client-factory/)
            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("Logging request!");
        }

    }
}
