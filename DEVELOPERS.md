# User API Dev Guide

* Swagger is included as part of the project and provides some mininum API documentation
* Starting the project in Visual Studio on localhost will fire up the swagger page where you can start interacting with the API
  
## Building
* Install .Net core 5
* Install Visual 2019
* Just run from Visual Studio using F5 and the API will fire up the swagger page
* Alternative use `dotnet build` from the project folder directory to build the project and `dotnet run` to run it

## Testing
* Unit tests can be run from Visual Studio using Resharper or the VS Test runner
* Alternatively unit tests can be run using `dotnet test` from the test projects folder
* Unit test coverage is basic, I've covered the business requirements mentioned in the README file.

## Deploying
* Have not included any deployment pipelines
* No physical database is being used, I'm using InMemory SQL database

## Additional Information
* Due to time constraint, I've used InMemory database. Time permitting would have used SQL Server, with kids at home and daycare closed due to lockdown, it has been a huge challenge juggling normal work and other coding tests sorry!
* When the API is started, using swagger you can create users and accounts. During a session data will be persisted in the inmemory database. If you stop the API, all data for that session is lost
* Time permitting, in a real production app, I would have included logging as it is critical for diagnosing issues in production
* Time permitting, I would have included more unit tests and tested the controller classes as well. At the moment I have written tests for the 2 key business requirements from the README file