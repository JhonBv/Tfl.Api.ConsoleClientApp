using Tfl.API.ConsoleClientApp.Exceptions;
using Tfl.API.ConsoleClientApp.Interfaces;

namespace Tfl.API.ConsoleClientApp.Services
{
    /// <summary>
    /// This class is only used after a NOT NULL Road Id have been passed.
    /// </summary>
    public class RequestValidatorService:IRequestValidator
    {
        public IResponseFactory _response;
        public IJObjectFactory _jObjectFactory;

        public RequestValidatorService(IResponseFactory response, IJObjectFactory jObjectFactory)
        {
            _jObjectFactory = jObjectFactory;
            _response = response;
        }
        public string returnResponse(string json)
        {
            var responseToClient = _response.BuildResponse(_jObjectFactory.ReturnAsJObect(json));
            return responseToClient;
        }

        public string ValidateRequest(string response, string road)
        {
     
            if (!response.StartsWith("OK"))
            {
                throw new InvalidRoadException(road.ToUpper());
            }

            return returnResponse(response.Substring(response.IndexOf('{')));
        }

    }
}
