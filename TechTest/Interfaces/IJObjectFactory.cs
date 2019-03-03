using Newtonsoft.Json.Linq;

namespace Tfl.API.ConsoleClientApp.Interfaces
{
    public interface IJObjectFactory
    {
        JObject ReturnAsJObect(string data);
    }
}
