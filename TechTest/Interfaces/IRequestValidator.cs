namespace Tfl.API.ConsoleClientApp.Interfaces
{
    public interface IRequestValidator
    {
        string returnResponse(string json);
        string ValidateRequest(string response, string road);
    }
}
