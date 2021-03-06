﻿using Moq;
using NUnit.Framework;

using Tfl.API.ConsoleClientApp.Configuration;
using Tfl.API.ConsoleClientApp.Factories;
using Tfl.API.ConsoleClientApp.Interfaces;
using Tfl.API.ConsoleClientApp.Services;

namespace Tfl.API.ConsoleClientApp.Tests
{
    [TestFixture]
    public class BaseTestClass
    {
        public string[] tflCredsentials;
        public string appId;
        public string appKey;
        public ResponseFactory responseFactory;
        public RequestValidatorService validator;
        public JObjectFactory jObjectFactory;
        public TflClientService tflClient;

        public Mock<IResponseFactory> _ResponseFactory;
        public Mock<IJObjectFactory> _JObjectFactory;
        public Mock<ITflClientService> _TflClient;

        public Configuration config;

        [SetUp]
        public void SetUp()
        {
            //ARRANGE
            //JB. Loading vals from text files (ignored by Git). This can be chanmged to point anywhere including an Azure vault.
            tflCredsentials = System.IO.File.ReadAllLines(@"TflApiDetails.txt");


            //ACT
            //JB. read the credentials from the text file
            appId = ClientConfiguration.app_id = tflCredsentials[0].ToString();
            appKey = ClientConfiguration.app_key = tflCredsentials[1].ToString();

            config = new Configuration();
        }

        [TearDown]
        public void tearDown()
        {
            tflCredsentials = null;
            appId = "";
            appKey = "";
        }
    }
}
