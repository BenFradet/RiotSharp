[![Stories in Ready](https://badge.waffle.io/benfradet/riotsharp.png?label=ready&title=Ready)](https://waffle.io/benfradet/riotsharp)
# RiotSharp

C# Wrapper for the [Riot Games API](https://developer.riotgames.com/)

##Features

- No need to worry about the 10 requests per 10s or the 500 requests per 10m rate limits, they are already implemented in the wrapper
- LINQ support
- Synchronous and asynchronous API
- Caching for the Static API

##Installation

1. Clone the repo (https://github.com/BenFradet/RiotSharp.git) or [download the zip file](https://github.com/BenFradet/RiotSharp/archive/master.zip).

2. Build the RiotSharp project and add the library to your own application.

##Usage

In order to use the api you need an api key which you can get [here](https://developer.riotgames.com/).

Entry point to the api:
```c#
var api = RiotApi.GetInstance("YOUR_API_KEY", false);
```

To get a summoner:
```c#
  var summoner = api.GetSummoner(Region.euw, "StopOFlop");
```

To get the stats in ranked for a specific champion for this summoner:
```c#
var varusRanked = summoner.GetStatsRanked(Season.Season3)
  .Where((s) => s.Name != null && s.Name.Equals("Varus"))
  .FirstOrDefault();
  
foreach (var stat in varusRanked.Stats)
  Console.WriteLine(stat.Name + "  " + stat.Value);
```

For a full description check the RiotSharpExample or RiotSharpTest projects.

##Contribution

Simply send a pull request.
When adding new features, please provide the related unit tests within the pull request.

##Libraries used

This wrapper uses [Json.NET](http://james.newtonking.com/json).

##Disclaimer
This product is not endorsed, certified or otherwise approved in any way by Riot Games, Inc. or any of its affiliates.
