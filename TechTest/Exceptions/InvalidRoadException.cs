using System;

namespace Tfl.API.ConsoleClientApp.Exceptions
{
    public class InvalidRoadException: Exception
    {
        public InvalidRoadException()
        {

        }

        public InvalidRoadException(string id):base(id + " is not a valid road")
        {

        }

        public InvalidRoadException(string message, Exception inner):base(message,inner)
        {

        }
    }
}
