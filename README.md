# RiotSharp

[![NuGet version](https://badge.fury.io/nu/RiotSharp.svg)](https://badge.fury.io/nu/RiotSharp) [![Build status](https://ci.appveyor.com/api/projects/status/2gbc0e50jeei2nuw/branch/develop?svg=true)](https://ci.appveyor.com/project/BenFradet/riotsharp/branch/develop) [![Stories in Ready](https://badge.waffle.io/benfradet/riotsharp.png?label=Ready)](https://waffle.io/benfradet/riotsharp)

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

###Game API
In order to use the api you need an api key which you can get [here](https://developer.riotgames.com/).

Entry point to the api if you do not own a production API key:
```c#
var api = RiotApi.GetInstance("YOUR_API_KEY");
```

If you do own a production API key you can specify your own rate limits:
```c#
var api = RiotApi.GetInstance("YOUR_API_KEY",
  yourRateLimitPer10s, yourRateLimitPer10m);
```

To get a summoner:
```c#
try
{
  var summoner = api.GetSummoner(Region.euw, "StopOFlop");
}
catch (RiotSharpException ex)
{
  // Handle the exception however you want.
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
catch (RiotSharpException ex)
{
  // Handle the exception however you want.
}

foreach (var stat in varusRanked.Stats)
{
  Console.WriteLine(stat.Name + "  " + stat.Value);
}
```

###Tournament API

You first have to apply for a tournament API key [here](https://developer.riotgames.com/).

Entry point for the tournament API:
```c#
var tournamentApi = TournamentRiotApi.GetInstance("TOURNAMENT_API_KEY");
```

Next up, create a provider.
The url will will receive callbacks callbacks with match results.
```c#
var provider = api.CreateProvider(region, url);
```

And create a tournament:
```c#
var tournament = api.CreateTournament(provider.Id, "TOURNAMENT_NAME");
```

Now you can create tournament codes (which you can use to join games):
```c#
var tournamentCode = api.CreateTournamentCode(tournament.Id, teamSize, allowedSummonerIds,
    TournamentSpectatorType.All, TournamentPickType.TournamentDraft,
    TournamentMapType.SummonnersRift, string.Empty);
```
The tournament code can now be entered in the client to join a game with the specified settings.


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
RiotSharp isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing League of Legends. League of Legends and Riot Games are trademarks or registered trademarks of Riot Games, Inc. League of Legends © Riot Games, Inc.
