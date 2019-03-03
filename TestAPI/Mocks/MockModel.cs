using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAPI.Models;

namespace TestAPI.Mocks
{
    public static class MockModel
    {
        public static TflModel GoodMock()
        {
            TflModel model = new TflModel
            {
                Type = "Tfl.Api.Presentation.Entities.RoadCorridor, Tfl.Api.Presentation.Entities",
                Id = "a2",
                displayName = "A@",
                statusSeverity = "Good",
                statusSeverityDescription = "No Exceptional Delays",
                bounds = "[[-0.0857, 51.44091],[0.17118, 51.49438]]",
                envelope = "[[-0.0857,51.44091],[-0.0857,51.49438],[0.17118,51.49438],[0.17118,51.44091],[-0.0857,51.44091]]",
                url = "/Road/a2"

            };

            return model;
        }

        public static TflbadResponseModel BadMock()
        {
            TflbadResponseModel model = new TflbadResponseModel
            {
                type = "Tfl.Api.Presentation.Entities.ApiError, Tfl.Api.Presentation.Entities",
                timestampUtc = DateTime.Now.ToString(),
                exceptionType = "EntityNotFoundException",
                httpStatusCode = "404",
                httpStatus = "NotFound",
                relativeUri = "/Road/A233",
                message = "The following road id is not recognised: A233"

            };

            return model;
        }
    }
}