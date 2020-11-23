# RiotSharp

[![Join the chat at https://gitter.im/BenFradet/RiotSharp](https://badges.gitter.im/BenFradet/RiotSharp.svg)](https://gitter.im/BenFradet/RiotSharp?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![NuGet version](https://badge.fury.io/nu/RiotSharp.svg)](https://badge.fury.io/nu/RiotSharp) [![Build status](https://ci.appveyor.com/api/projects/status/2gbc0e50jeei2nuw/branch/develop?svg=true)](https://ci.appveyor.com/project/BenFradet/riotsharp/branch/develop)
[![Discord](https://discordapp.com/api/guilds/659680058788544556/widget.png)](https://discord.gg/58eQar4)

C# Wrapper for the [Riot Games API](https://developer.riotgames.com/)

<!---
 Documentation can be found [here](http://benfradet.github.io/RiotSharp/api/index.html).
--->
## Features

- No need to worry about the 10 requests per 10s or the 500 requests per 10m rate limits, they are already implemented in the wrapper
- LINQ support
- Synchronous and asynchronous API
- Caching for the DataDragon (Static API)

## Installation

Install RiotSharp through NuGet:
```
PM> Install-Package RiotSharp
```

or

1. Clone the repo (https://github.com/BenFradet/RiotSharp.git) or [download the zip file](https://github.com/BenFradet/RiotSharp/archive/develop.zip).

2. Build the RiotSharp project and add the library to your own application.

### Build your own latest NuGet package
You can build your own NuGet package of the latest version with the following command:
```
dotnet pack /p:Configuration=Release
```
Execute it from the Visual Studio developer command prompt from inside the RiotSharp project folder. 
Then copy the `RiotSharp.*.nupkg` file from the `bin` folder into your local NuGet feed. [Create local NuGet feed](https://docs.microsoft.com/en-us/nuget/tools/package-manager-ui#package-sources)

## Usage

### Main API
In order to use the API you need an API key which you can get [here](https://developer.riotgames.com/).

Entry point to the API if you do not own a production API key:
```c#
var api = RiotApi.GetDevelopmentInstance("YOUR_API_KEY");
```

If you do own a production API key you can specify your own rate limits:
```c#
var api = RiotApi.GetInstance("YOUR_API_KEY",
  yourRateLimitPer10s, yourRateLimitPer10m);
```

To get basic data of a summoner:
```c#
try
{
  var summoner = api.Summoner.GetSummonerByNameAsync(Region.Euw, "SUMMONER_NAME").Result;
  var name = summoner.Name;
  var level = summoner.Level;
  var accountId = summoner.AccountId;
}
catch (RiotSharpException ex)
{
  // Handle the exception however you want.
}
```
Each class represents an API:
* Account
* Champion
* League  
* Match  
* Spectator  
* Status  
* Summoner 
* ChampionMastery  
* StaticData  
* ThirdParty  


You can find a list of all the available operations in [RiotApi in the documentation](http://benfradet.github.io/RiotSharp/api/RiotSharp.RiotApi.html) 
or test some queries on the [Riot Developer Portal](https://developer.riotgames.com/apis)

### Tournament API

You first have to apply for a tournament API key [here](https://developer.riotgames.com/).

Entry point for the tournament API:
```c#
var tournamentApi = TournamentRiotApi.GetInstance("TOURNAMENT_API_KEY");
```

Next up, create a provider.
The url will receive callbacks with match results.
```c#
var provider = tournamentApi.CreateProvider(Region.Euw, url);
```

And create a tournament:
```c#
var tournament = tournamentApi.CreateTournament(provider.Id, "TOURNAMENT_NAME");
```

Now you can create tournament codes (which you can use to join games):
```c#
var tournamentCode = tournamentApi.CreateTournamentCode(tournament.Id,
    teamSize, allowedSummonerIds, TournamentSpectatorType.All,
    TournamentPickType.TournamentDraft, TournamentMapType.SummonnersRift,
    string.Empty);
```

The tournament code can now be entered in the client to join a game with the specified settings.
Please note that you should save the provider and tournament IDs if you wish to create more tournament codes later on. You should not create a separate provider and tournament ID for every tournament code. Make sure to read Riot's [guidelines](https://developer.riotgames.com/docs/tournaments-api) on this topic.

To create a Tournament object for an existing tournament, use the following syntax:
```c#
var tournament = new Tournament { Id = id };
```

You can then create codes in two ways:
```c#
tournament.CreateTournamentCode(teamSize, allowedSummonerIds,
    TournamentSpectatorType.All, TournamentPickType.TournamentDraft,
    TournamentMapType.SummonnersRift, string.Empty);
```

or, alternatively, if you do not wish to create a separate Tournament object, you can call the `CreateTournamentCode` method directly from the API as shown previously.

You can find a list of all the available operations in [TournamentRiotApi in the documentation](http://benfradet.github.io/RiotSharp/api/RiotSharp.TournamentRiotApi.html).

### Data Dragon / Static API

You can retrieve static information about the game thanks to the static API (Data Dragon), there is no rate limiting on this API and RiotSharp
caches as much data as possible to make as few calls as possible.

DataDragon API is hidden in Main API.
```c#
var someData = api.DataDragon.SomeEndpoint.SomeMethod();
```

For example, you can retrieve data about all champions:
```c#
var allVersion = api.DataDragon.Versions.GetAllAsync().Result;
var latestVersion = allVersion[0]; // Example of version: "10.23.1"
var champions = api.DataDragon.Champions.GetAllAsync(latestVersion).Result.Champions.Values;
foreach (var champion in champions)
{
    Console.WriteLine(champion.Name);
    Console.WriteLine(champion.Lore);
}
```

Additionally, you can use the regular API and static API to, for example, retrieve champion masteries for the summoner:
```c#
List<ChampionMastery> championMasteries;
try
{
    championMasteries =  api.ChampionMastery.GetChampionMasteriesAsync(summoner.Region, summoner.Id).Result;
}
catch (RiotSharpException ex)
{
    // Handle the exception however you want.
    return;
}

foreach (var championMastery in championMasteries)
{
    var id = championMastery.ChampionId;
    var name = api.DataDragon.Champions.GetAllAsync(latestVersion).Result.Champions.Values.Single(x => x.Id == id).Name; // using System.Linq;
    var level = championMastery.ChampionLevel;
    var points = championMastery.ChampionPoints;

    Console.WriteLine($" •  **Level {level} {name}** {points} Points");
}
```

For a full description check the [RiotSharpTest](RiotSharpTest) project.

## Contribution

Simply send a pull request! The [up-for-grabs](https://github.com/BenFradet/RiotSharp/labels/up-for-grabs) label is a great place to start.

When adding new features, please provide the related unit tests within the pull request.
To run the unit tests you need to modify the [App.config](RiotSharpTest/App.config) file and fill out the appropriate values so the tests can run.

Moreover, the documentation is far from perfect so every bit of help is more than welcome.

## Libraries used

This wrapper uses [Json.NET](http://james.newtonking.com/json).

## License

This wrapper is under the [MIT license](LICENSE.md).

## Disclaimer

RiotSharp isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing League of Legends. League of Legends and Riot Games are trademarks or registered trademarks of Riot Games, Inc. League of Legends © Riot Games, Inc.
