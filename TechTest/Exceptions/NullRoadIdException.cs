using System;

namespace Tfl.API.ConsoleClientApp.Exceptions
{
    public class NullRoadIdException:Exception
    {
        public NullRoadIdException()
        {

        }

        public NullRoadIdException(string id):base(id + " Road Id cannot be null!")
        {

        }
    }
}
