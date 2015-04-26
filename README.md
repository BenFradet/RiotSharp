# RiotSharp [![Stories in Ready](https://badge.waffle.io/benfradet/riotsharp.png?label=Ready)](https://waffle.io/benfradet/riotsharp) [![Build status](https://ci.appveyor.com/api/projects/status/2gbc0e50jeei2nuw/branch/master)](https://ci.appveyor.com/project/BenFradet/riotsharp/branch/master)

C# Wrapper for the [Riot Games API](https://developer.riotgames.com/)

##Features

- No need to worry about the 10 requests per 10s or the 500 requests per 10m rate limits, they are already implemented in the wrapper
- LINQ support
- Synchronous and asynchronous API
- Caching for the Static API

##Installation

Install RiotSharp through NuGet:
```
PM> Install-Package RiotSharp
```

or

1. Clone the repo (https://github.com/BenFradet/RiotSharp.git) or [download the zip file](https://github.com/BenFradet/RiotSharp/archive/master.zip).

2. Build the RiotSharp project and add the library to your own application.

##Usage

In order to use the api you need an api key which you can get [here](https://developer.riotgames.com/).

Entry point to the api if you do not own a production API key:
```c#
var api = RiotApi.GetInstance("YOUR_API_KEY");
```

If you do own a production API key you can specify your own rate limits:
```c#
var api = RiotApi.GetInstance("YOUR_API_KEY",
  your_rate_limit_per_10s, your_rate_limit_per_10m);
```

To get a summoner:
```c#
try
{
  var summoner = api.GetSummoner(Region.euw, "StopOFlop");
}
catch(RiotSharpException ex)
{
  //Handle the exception however you want.
}
```

To get the stats in ranked for a specific champion for this summoner:
```c#
try
{
  var varusRanked = summoner.GetStatsRanked(Season.Season3)
    .Where((s) => s.Name != null && s.Name.Equals("Varus"))
    .FirstOrDefault();
}
catch(RiotSharpException ex)
{
  //Handle the exception however you want.
}
  
foreach (var stat in varusRanked.Stats)
  Console.WriteLine(stat.Name + "  " + stat.Value);
```

For a full description check the RiotSharpExample or RiotSharpTest projects.

##Contribution

Simply send a pull request!

When adding new features, please provide the related unit tests within the pull request.
To run the unit tests you need to modify the [App.config](RiotSharpTest/App.config) file and fill out the appropriate values so the tests can run.

Moreover, the documentation is far from perfect so every bit of help is more than welcome.

##Libraries used

This wrapper uses [Json.NET](http://james.newtonking.com/json).

##License

This wrapper is under the [MIT license](LICENSE.md).

##Disclaimer
This product is not endorsed, certified or otherwise approved in any way by Riot Games, Inc. or any of its affiliates.
