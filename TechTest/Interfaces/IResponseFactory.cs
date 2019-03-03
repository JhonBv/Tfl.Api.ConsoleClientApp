using Newtonsoft.Json.Linq;

namespace Tfl.API.ConsoleClientApp.Interfaces
{
    public interface IResponseFactory
    {
        string BuildResponse(JObject data);
    }
}
