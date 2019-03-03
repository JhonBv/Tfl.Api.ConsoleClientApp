using Tfl.API.ConsoleClientApp.MockObjects;
using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Tfl.API.ConsoleClientApp.Exceptions;
using Tfl.API.ConsoleClientApp.Factories;
using Tfl.API.ConsoleClientApp.Interfaces;
using FluentAssertions;

namespace ClientTests
{
    [TestFixture]
    public class RoadInformationTests:BaseTestClass
    {
        [Test]
        public void Given_a_Valid_Road_Id_Is_Specified_Return_Road_Name()
        {            
            //Arrange
            responseFactory = new ResponseFactory();
            var _mock = new Mock<IResponseFactory>();
            _JObjectBuilder = new Mock<IJObjectFactory>();

            //Act
            _mock.Setup(x => x.BuildResponse(It.IsAny<JObject>())).Returns(responseFactory.BuildResponse(MockResponse.ValidResponse("a4")));
            _JObjectBuilder.Setup(o=>o.ReturnAsJObect(MockResponse.ValidHttpResponseMock("A4"))).Equals(typeof(JObject));

            //Assert
            _JObjectBuilder.Verify();


            Assert.That(_mock.Object, Is.Not.Null);
           

            //JB. Check that the Road name is returned.
            Assert.That(_mock.Object.BuildResponse(MockResponse.ValidResponse("a4")), Contains.Substring("A4"));

        }

        [Test]
        public void Given_a_Valid_Road_Id_Is_Specified_Return_Road_Status()
        {
            //Arrange
            _ResponseFactory = new Mock<IResponseFactory>();

            //Act
            _ResponseFactory.Setup(x => x.BuildResponse(It.IsAny<JObject>())).Returns(responseFactory.BuildResponse(MockResponse.ValidResponse("a4")));
            _ResponseFactory.Verify();

            //Assert
            Assert.That(_ResponseFactory.Object, Is.Not.Null);

            //JB. Check that the Road status is returned
            Assert.That(_ResponseFactory.Object.BuildResponse(MockResponse.ValidResponse("a4")), Contains.Substring("Road status"));

        }
        [Test]
        public void Given_a_Valid_Road_Id_Is_Specified_Return_Road_Status_Description()
        {
            //Arrange
            _ResponseFactory = new Mock<IResponseFactory>();
            _ResponseFactory.Setup(x => x.BuildResponse(It.IsAny<JObject>())).Returns(responseFactory.BuildResponse(MockResponse.ValidResponse("a4")));

            //Act
            _ResponseFactory.Verify();
            
            //Assert
            Assert.That(_ResponseFactory.Object, Is.Not.Null);
            
            //JB. Check that the Road status Description is returned
            Assert.That(_ResponseFactory.Object.BuildResponse(MockResponse.ValidResponse("a4")),Contains.Substring("Road status Description"));
        }

        //Invalid ID tests
        [Test]
        public void Given_An_Invalid_Road_Id_Is_Specified_Return_An_Informative_Error()
        {
            //Arrange
            var _mock = new Mock<IRequestValidator>();
            _mock.Setup(x => x.ValidateRequest( MockResponse.InvalidHttpResponseMock(), "A333")).Throws<InvalidRoadException>();
            
            //Act
            var invalidRoad = new InvalidRoadException("A333");

            //Assert
            _mock.Verify();

            //JB. Check that an informative message is returned
            Assert.That(invalidRoad.Message.Contains(" is not a valid road"));
        }


        /// <summary>
        /// In order to validate a user input, it has been decided to do this at the biginning in the Program class.
        /// Since this class cannot be mocket, we use only a Unit Test for the corresponding Exception handler.
        /// </summary>
        [Test]
        public void Given_An_Empty_String_Is_Passed_to_ResponseBuilder_Send_Error_Message()
        {
            //Arrange
            var nullRoadIdException = new NullRoadIdException("");

            //Assert

            nullRoadIdException.Message.Should().Contain("Road Id cannot be null!");
            //Assert.That(nullRoadIdException.Message.Contains("Road Id cannot be null!"));
        }
    }
}
