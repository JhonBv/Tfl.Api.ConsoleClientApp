
using System.Threading.Tasks;

namespace Tfl.API.ConsoleClientApp.Interfaces
{
    public interface IHttpClientFactoryService
    {
        Task<string> GetRoadInformation(string path);
    }
}
