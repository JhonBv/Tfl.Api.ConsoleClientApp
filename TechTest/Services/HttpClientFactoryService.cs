using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Tfl.API.ConsoleClientApp.Helpers;
using Tfl.API.ConsoleClientApp.Interfaces;

namespace Tfl.API.ConsoleClientApp.Services
{
    /// <summary>
    /// JB. Creates the required HttpClient service.
    /// </summary>
    public class HttpClientFactoryService:IHttpClientFactoryService
    {
        HttpClient HttpClient { get; }        
        public HttpClientFactoryService(HttpClient client)
        {
            HttpClient = client;
            HttpClient.BaseAddress = new Uri("https://api.tfl.gov.uk/Road/");

            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Add("cache-control", "no-cache");

            //JB This is only in case of a POST, however I will leave it here in case the app will also send POST requests in the future.
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        /// <summary>
        /// JB. Get road information from the Tfl API.
        /// </summary>
        /// <param name="path">the Endpoint to be consumed (i.e. A2?app_id=123&app_key=1234)</param>
        /// <returns>String Json to be consumed</returns>
        public async Task<string> GetRoadInformation(string path)
        {
            HttpResponseMessage response = await HttpClient.GetAsync(path);
            var jsonResult = JsonResultFormatter.FormatJsonString(response.Content.ReadAsStringAsync().Result);

            StringBuilder builder = new StringBuilder();

            builder.Append(response.StatusCode.ToString());
            builder.Append(jsonResult);

            return builder.ToString();
        }
    }
}
