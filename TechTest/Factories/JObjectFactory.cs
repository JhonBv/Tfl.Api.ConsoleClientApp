using Newtonsoft.Json.Linq;
using Tfl.API.ConsoleClientApp.Interfaces;

namespace Tfl.API.ConsoleClientApp.Factories
{
    /// <summary>
    /// Builds and returns a Dynamyc object so its properties can be accessed dynamically.
    /// </summary>
    public class JObjectFactory : IJObjectFactory
    {
        public JObject ReturnAsJObect(string data)
        {
            //Parse the returned string into a Json Object then turn it a dynamic object.
            JObject o = JObject.Parse(data);
            
            return o;
        }
    }
}
