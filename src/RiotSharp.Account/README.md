# RiotSharp.Account

Riot Account API wrapper for RiotSharp - C# wrapper for the Riot Games API.

## Features

- Riot Account management endpoints
- Account information retrieval
- Active shard and region data
- Cross-game account services
- Built on top of RiotSharp.Core with automatic rate limiting and caching

## Installation

```bash
dotnet add package AV.RiotSharp.Account
```

## Usage

```csharp
using RiotSharp.Account;

// Initialize the API client
var apiKey = "your-riot-api-key";
var accountApi = new RiotAccount(apiKey);

// Example: Get account by Riot ID
var account = await accountApi.GetByRiotIdAsync("GameName", "TagLine");

// Example: Get account by PUUID
var accountByPuuid = await accountApi.GetByPuuidAsync("puuid");

// Example: Get active shard for a player
var shard = await accountApi.GetActiveShardAsync("Game", "puuid");
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
