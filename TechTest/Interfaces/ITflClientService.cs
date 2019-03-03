using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Tfl.API.ConsoleClientApp.Interfaces
{
    public interface ITflClientService
    {
        Task<string> InitializeClient(string road, ServiceCollection services);
    }
}
