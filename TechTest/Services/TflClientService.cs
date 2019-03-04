using System.Threading.Tasks;
using Tfl.API.ConsoleClientApp.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Tfl.API.ConsoleClientApp.Configuration;

namespace Tfl.API.ConsoleClientApp.Services
{
    /// <summary>
    /// JB. Client implementation of the HttpClient.
    /// </summary>
    public class TflClientService:ITflClientService
    {
        private readonly IResponseFactory _response;

        public TflClientService(IResponseFactory _response)
        {
            this._response = _response;
        }
        /// <summary>
        /// JB. Initialise TFL Client.
        /// </summary>
        /// <param name="daRoad"></param>
        /// <param name="services"></param>
        /// <returns></returns>
        public async Task<string> InitializeClient(string daRoad, ServiceCollection services)
        {
            ConfigureClient();
            var serviceProvider = services.BuildServiceProvider();
            return await InitializeHttpFactory(serviceProvider, daRoad);
        }

        /// <summary>
        /// JB. Load the configuration of the App.
        /// </summary>
        protected void ConfigureClient()
        {
            //JB. Loading vals from text files (ignored by Git). This can be chanmged to point anywhere including an Azure vault.
            string[] tflCreds = System.IO.File.ReadAllLines(@"TflApiDetails.txt");

            //JB. read the credentials from the text file
            var appId = ClientConfiguration.app_id = tflCreds[0].ToString();
            var appKey = ClientConfiguration.app_key = tflCreds[1].ToString();
        }

        /// <summary>
        /// JB. Initialise the HttpClient Factory and send the GET request
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="daRoad"></param>
        /// <returns></returns>
        protected async Task<string> InitializeHttpFactory(ServiceProvider serviceProvider, string daRoad)
        {
            string returnedJson = "";
            var tfl = serviceProvider.GetRequiredService<HttpClientFactoryService>();
            return returnedJson = await tfl.GetRoadInformation(daRoad.ToUpper() + "?app_id=" + ClientConfiguration.app_id + "&app_key=" + ClientConfiguration.app_key);
        }
    }
}
