using System.Text;
using Newtonsoft.Json.Linq;
using Tfl.API.ConsoleClientApp.Interfaces;
using Tfl.API.ConsoleClientApp.Models;

namespace Tfl.API.ConsoleClientApp.Factories
{
    /// <summary>
    /// JB. Return a response as a String once the JObject has been processed.
    /// This class will only be invoked if a Request has been successful (contains an OK or 200)
    /// Validation of input happens at the Program class (Program.cs) and then validated by the IRequestValidator Object.
    /// </summary>
    public class ResponseFactory : IResponseFactory
    {
        public string BuildResponse(JObject jObject)
        {
            StringBuilder response = new StringBuilder();
            
            var responseModel = new ValidResponseModel
            {
                displayName = (string)jObject["displayName"],
                statusSeverity = (string)jObject["statusSeverity"],
                statusSeverityDescription = (string)jObject["statusSeverityDescription"]
            };

            response.AppendLine("The status of the " + responseModel.displayName + " is as follows");
            response.AppendLine("Road status is " + responseModel.statusSeverity);
            response.AppendLine("Road status Description is " + responseModel.statusSeverityDescription);

            return response.ToString();
        }
        
    }
}
