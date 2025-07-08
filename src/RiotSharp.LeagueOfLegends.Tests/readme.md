Add an appsettings.json file to the root of the test project containing the following:

{
  "ApiKey": "yourapikey"
}

The apikey will the be accessed by the TestContextFixture class(needs a better name).
Add [Collection("Shared fixture")] at the top of each new test class that requires the shared fixture.