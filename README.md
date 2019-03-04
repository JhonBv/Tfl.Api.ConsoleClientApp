
#  Tfl Console Client App

##  Contents
There exists three folders in the solution:
* TechTest
* ClientTests
* ApiTest

#### PLEASE IGNORE the ApiTest proyect as it was created so that off-line development could be possible.
## Solution Structure
The solution contains two projects:
#### Tfl.API.ConsoleClientApp.
The Tfl.API.ConsoleClientApp project is where all the logic is executed and the TFL Road Information API is consumed.
#### Tfl.API.ConsoleClientApp.Tests
The Tfl.API.ConsoleClientApp.Tests project contains all the unit testing and Mocking of the API responses.
## Project dependencies

#### Tfl.API.ConsoleClientApp.
* Microsoft.AspNet.WebApi.Client 5.2.7
* Microsoft.Extensions.DependencyInjection 2.2.0
* Microsoft.Extensions.Http 2.2.0
* Microsoft.Extensions.Logging 2.2.0
* Serilog.Extensions.Logging 2.0.2
* Serilog.Sinks.Console 3.1.1

#### Tfl.API.ConsoleClientApp.Tests
* FluentAssertions 5.6.0
* MOQ 4.10.1
* NUnit.ConsoleRunner 3.9.0
## How to use

Download the project to a location in your hard drive.
## Register for a developer account at TFL
Register in the following  url:  [https://api-portal.tfl.gov.uk/](https://api-portal.tfl.gov.uk/)

## Configure API Keys
Once registered with the TFL API, create a text file in the root of the project or a file that you can easily reference. Name the file TflApiDetails.txt. Type first the App_Id and below it, type the App_Key (as below)
```
23334444
122222223334445
```

Open the command line and navigate to the folder where the project has been downloaded/copied.

## Run the Application to obtain roads information

#### type the following command in your console:

```bash

{yourPath}\TechTest\TechTest\bin\Debug\netcoreapp2.1>dotnet TechTest.dll

```

![MS Console](\ConsoleCapture.PNG)


# Improvements
Every time I look at my code I realise that it can become even better. I acknowledge that refactoring is a key part of every system and it is a key skill for us, developers. I have taken much care in trying to identify quialifying classes etc for refactoring whilst also trying not to over engineer the application. Although much work can be done, I have listed below few that I think should be looked into more detail.

## Best use of HttpClient Factory

In this project I made an effort to use the Microsoft HttpClient Factory. I would always recommend it specially for apps where many Http Client services are needed. Even though this app only uses one service for now, if it is to grow and be able to lets say, obtain road information not only from London but for the entire UK and we have to consume more than one API, it will make perfect sense to use the HttpClient factory. A good guide into this can be found at https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests

## API Credentials

For the sake of this small exercise, the Api keys are stored in a plain text file (git ignored) however, if this app should be hosted in an Azure service, a proper storing mechanism such as Azure vault could have been used.

## Unit Testing
Unit testing could have been written in an even cleaner way, for example by using SpecFlow (https://specflow.org/) to properly test behaviours (BDD). I tried to use it but I was not successful as I am not 100% familiar of how it works in .Net Core.

## FluentAssertions

I had an issue with the following:
```
_mock.Object.ValidateRequest(MockResponse.InvalidHttpResponseMock(), "a333").Should().Throw<InvalidRoadException>();
```
It seems that the .Throw<Exception>() extension method is not supported anymore in the latest version. I need to investigate about this more.

I would also like to perform proper reuse of DI from the Client App rather than doing it again in the Test project.

 
