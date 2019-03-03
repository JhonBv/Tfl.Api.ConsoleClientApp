
namespace Tfl.API.ConsoleClientApp.Helpers
{
    /// <summary>
    /// JB. Removes characters that would otherwise cause problems with the Json reader.
    /// </summary>
    public static class JsonResultFormatter
    {
        public static string FormatJsonString(string data)
        {
            //JB. remove the '[' and ']' to avoid having an array
            string finalJson = data.StartsWith("[")? data.Substring(1, data.Length - 2):data;
            
            //JB. Return a really clean response by removing the $ symbol
            return finalJson.Replace("$", "");
        }

        
    }
}
