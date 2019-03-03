using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAPI.Models
{
    public class TflbadResponseModel
    {
        public string type { get; set; }
        public string timestampUtc { get; set; }
        public string exceptionType { get; set; }
        public string httpStatusCode { get; set; }
        public string httpStatus { get; set; }
        public string relativeUri { get; set; }
        public string message { get; set; }
        

    }
}