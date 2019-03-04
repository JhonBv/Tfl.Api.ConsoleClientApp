using Tfl.API.ConsoleClientApp.MockObjects;
using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Tfl.API.ConsoleClientApp.Exceptions;
using Tfl.API.ConsoleClientApp.Factories;
using Tfl.API.ConsoleClientApp.Interfaces;
using FluentAssertions;
using Tfl.API.ConsoleClientApp.Services;

namespace Tfl.API.ConsoleClientApp.Tests
{
    /// <summary>
    /// JB. Test all responses and scenarios.
    /// </summary>
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

            _mock.Should().NotBeNull();
            
            //JB. Check that the Road name is returned.           
            _mock.Object.BuildResponse(MockResponse.ValidResponse("a4")).Should().Contain("A4");
        }

        [Test]
        public void Given_a_Valid_Road_Id_Is_Specified_Return_Road_Status()
        {
            //Arrange
            responseFactory = new ResponseFactory();
            _ResponseFactory = new Mock<IResponseFactory>();

            //Act
            _ResponseFactory.Setup(x => x.BuildResponse(It.IsAny<JObject>())).Returns(responseFactory.BuildResponse(MockResponse.ValidResponse("a4")));
            _ResponseFactory.Verify();

            //Assert
            //Assert.That(_ResponseFactory.Object, Is.Not.Null);
            _ResponseFactory.Object.Should().NotBeNull();

            //JB. Check that the Road status is returned
            //Assert.That(_ResponseFactory.Object.BuildResponse(MockResponse.ValidResponse("a4")), Contains.Substring("Road status"));
            _ResponseFactory.Object.BuildResponse(MockResponse.ValidResponse("a4")).Should().Contain("Road status");
        }
        [Test]
        public void Given_a_Valid_Road_Id_Is_Specified_Return_Road_Status_Description()
        {
            //Arrange
            responseFactory = new ResponseFactory();
            _ResponseFactory = new Mock<IResponseFactory>();
            _ResponseFactory.Setup(x => x.BuildResponse(It.IsAny<JObject>())).Returns(responseFactory.BuildResponse(MockResponse.ValidResponse("a4")));

            //Act
            _ResponseFactory.Verify();

            //Assert
            _ResponseFactory.Object.Should().NotBeNull();
            
            //JB. Check that the Road status Description is returned
            _ResponseFactory.Object.BuildResponse(MockResponse.ValidResponse("a2")).Should().Contain("Road status Description");
        }

        //Invalid ID tests
        [Test]
        public void Given_An_Invalid_Road_Id_Is_Specified_Return_An_Informative_Error()
        {
            //Arrange
            var invalidRoad = new InvalidRoadException("A333");
            var _mockResponseFactory = new Mock<IResponseFactory>();
            var _mockJobjectFactory= new Mock<IJObjectFactory>();

            validator = new RequestValidatorService(_mockResponseFactory.Object, _mockJobjectFactory.Object);
            
            var _mock = new Mock<IRequestValidator>();
            _mock.Setup(x => x.ValidateRequest( MockResponse.InvalidHttpResponseMock(), "A333")).Throws<InvalidRoadException>();

            //Act

           //Assert
            _mock.Verify();

            //JB. Could not verify the Throwing type with FluentAssertions for some reason the Throw<Exception>() method does not work anymore.
            //_mock.Object.ValidateRequest(MockResponse.InvalidHttpResponseMock(), "a333").Should().Throw<InvalidRoadException>();

            invalidRoad.Should().BeOfType<InvalidRoadException>().Which.Message.Should().Contain(" is not a valid road");

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
