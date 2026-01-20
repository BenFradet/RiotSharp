# RiotSharp.LeagueOfLegends

League of Legends API wrapper for RiotSharp - C# wrapper for the Riot Games API.

## Features

- Complete League of Legends API coverage
- Champion Mastery endpoints
- Summoner information
- Match history and details
- League and ranked data
- Champion rotation
- Built on top of RiotSharp.Core with automatic rate limiting and caching

## Installation

```bash
dotnet add package AV.RiotSharp.LeagueOfLegends
```

## Usage

```csharp
using RiotSharp.LeagueOfLegends;

// Initialize the API client
var apiKey = "your-riot-api-key";
var lolApi = new LeagueOfLegends(apiKey);

// Example: Get summoner information
var summoner = await lolApi.Summoner.GetByNameAsync("Region", "SummonerName");

// Example: Get champion mastery
var masteries = await lolApi.ChampionMastery.GetAllAsync("Region", summoner.Id);
```

## Dependencies

This package depends on:
- **AV.RiotSharp.Core** - Provides rate limiting, caching, and base infrastructure

## Development

For local development, this project uses ProjectReferences to RiotSharp.Core. During NuGet packaging, these are automatically converted to PackageReferences to ensure proper dependency resolution for consumers.

## Documentation

For full documentation, examples, and API reference, see the main [RiotSharp repository](https://github.com/asbjornvad/RiotSharp).

## License

This project is licensed under the MIT License - see the [LICENSE.md](../../LICENSE.md) file for details.
