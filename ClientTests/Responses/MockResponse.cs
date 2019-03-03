using Newtonsoft.Json.Linq;
using Tfl.API.ConsoleClientApp.Models;

namespace Tfl.API.ConsoleClientApp.MockObjects
{
    public static class MockResponse
    {
        public static JObject ValidResponse(string id)
        {
            var daResponse = new ValidResponseModel {

                displayName = id.ToUpper(),
                statusSeverity="Good",
                statusSeverityDescription= "No Exceptional Delays"
            };

            return JObject.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(daResponse));
        }

        public static JObject InvalidResponse(string id)
        {
            var daResponse = new NotFoundResponseModel
            {
                id = id,
                message = id + " is not a valid road"
            };

            return JObject.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(daResponse));
        }

        public static string ValidHttpResponseMock(string id)
        {
            return "{OK\"type\":\"Tfl.Api.Presentation.Entities.RoadCorridor, Tfl.Api.Presentation.Entities\",\"id\":\"a4\",\"displayName\":\"A4\",\"statusSeverity\":\"Good\",\"statusSeverityDescription\":\"No Exceptional Delays\",\"bounds\":\"[[-0.50067,51.44671],[-0.15236,51.50294]]\",\"envelope\":\"[[-0.50067,51.44671],[-0.50067,51.50294],[-0.15236,51.50294],[-0.15236,51.44671],[-0.50067,51.44671]]\",\"url\":\"/Road/a4\"}";
        }

        public static string InvalidHttpResponseMock()
        {
            return "{NotFound\"type\":" +
                "\"Tfl.Api.Presentation.Entities.ApiError, Tfl.Api.Presentation.Entities\"," +
                "\"timestampUtc\":\"2019-03-02T14:46:45.2908811Z\"," +
                "\"exceptionType\":\"EntityNotFoundException\"," +
                "\"httpStatusCode\":\"404\"," +
                "\"httpStatus\":\"NotFound\"," +
                "\"relativeUri\":\"/Road/A333\",\"message\":\"The following road id is not recognised: A333\"";
        }
    }
}
