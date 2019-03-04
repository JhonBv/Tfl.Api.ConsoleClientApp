
#  Tfl Console Client App

##  Structure

The solution contains two projects:
#### Tfl.API.ConsoleClientApp.
The Tfl.API.ConsoleClientApp project is where all the logic is executed and the TFL Road Information API is consumed.
#### Tfl.API.ConsoleClientApp.Tests
The Tfl.API.ConsoleClientApp.Tests project contains all the unit testing and Mocking of the API responses.

#  How to use

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
Include logo/demo screenshot etc.
![MS Console](/ConsoleCapture.PNG)


# Improvements