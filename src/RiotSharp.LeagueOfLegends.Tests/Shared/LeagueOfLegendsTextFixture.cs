using Microsoft.Extensions.Configuration;
using RiotSharp.Core.Http.Interfaces;
using RiotSharp.Core.Http.RateLimiting;
using RiotSharp.Core.Http.Requesters;
using RiotSharp.LeagueOfLegends.Endpoints.ChampionMasteryEndpoint;
using RiotSharp.LeagueOfLegends.Endpoints.ChampionRotationEndpoint;
using RiotSharp.LeagueOfLegends.Endpoints.ClashEndpoint;
using RiotSharp.LeagueOfLegends.Endpoints.LeagueEndpoint;
using RiotSharp.LeagueOfLegends.Endpoints.ChallengesEndpoint;
using Xunit.Abstractions;
using Xunit.Sdk;
using RiotSharp.LeagueOfLegends.Endpoints.StatusEndpoint;

namespace RiotSharp.LeagueOfLegends.Tests.Shared
{
	[CollectionDefinition("Shared fixture")]
	public class LeagueOfLegendsTextFixtureCollection : ICollectionFixture<LeagueOfLegendsTextFixture>
	{
		// This class has no code, and is never created. Its purpose is simply
		// to be the place to apply [CollectionDefinition] and all the
		// ICollectionFixture<> interfaces.
	}

	public class LeagueOfLegendsTextFixture : IDisposable
	{
		private string? ApiKey { get; }
		
		private Dictionary<TimeSpan, int> RateLimits { get; } = new()
		{
			[TimeSpan.FromSeconds(1)] = 20,
			[TimeSpan.FromMinutes(2)] = 100
		};

		private IRateLimitedRequester Requester { get; }

		public LeagueOfLegends LeagueOfLegends { get; private set; }

		public LeagueOfLegendsTextFixture()
		{
			var config = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.Build();

			ApiKey = config["ApiKey"];
			if (string.IsNullOrWhiteSpace(ApiKey))
				throw new InvalidOperationException("API key missing from appsettings.json");

			var httpRequester = new HttpRequester(new HttpClient());

			Requester = new RateLimitedRequester(ApiKey, httpRequester,
				new ApplicationRateLimiter(RateLimits),
				new ApplicationRateLimiter(RateLimits));

			// Build the LeagueOfLegends instance with the required endpoints that need to be tested
			LeagueOfLegends = new LeagueOfLegends.Builder()
				.UseChampionMasteryEndpoint(new ChampionMasteryEndpoint(Requester))
				.UseChampionRotationEndpoint(new ChampionRotationEndpoint(Requester))
				.UseClashEndpoint(new ClashEndpoint(Requester))
				.UseLeagueEndpoint(new LeagueEndpoint(Requester))
				.UseChallengesEndpoint(new ChallengesEndpoint(Requester))
				.UseStatusEndpoint(new StatusEndpoint(Requester))
                .Build();
		}

		public void Dispose()
		{ }
	}
}