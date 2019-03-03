using NUnit.Framework;
using Tfl.API.ConsoleClientApp.Configuration;

namespace ClientTests
{
    [TestFixture]
    public class ConfigurationTests:BaseTestClass
    {
        [Test]
        //Make sure both, appkey and appid are in the file. BaseClass have alreaddy the first AA of the AAA approach implemented.
        public void I_Have_Configfured_Api_Keys_In_File()
        {
            //ASSERT

            //make sure that the first value corresponds to the appid (the appkey usually is longer than the appid)
            Assert.IsNotNull(tflCredsentials);
            Assert.That(tflCredsentials[0].Length < tflCredsentials[1].Length);
            Assert.IsNotNull(appId);
            Assert.IsNotNull(appKey);
        }


    }
}
