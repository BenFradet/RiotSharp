using Microsoft.Extensions.Configuration;
using RiotSharp.Core.Http.Interfaces;
using RiotSharp.Core.Http.RateLimiting;
using RiotSharp.Core.Http.Requesters;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace RiotSharp.LeagueOfLegends.Tests.Shared
{
	public class TestContextFixture : IAsyncLifetime
	{
		public string ApiKey { get; private set; }
		
		public Dictionary<TimeSpan, int> RateLimits { get; } = new()
		{
			[TimeSpan.FromSeconds(1)] = 20,
			[TimeSpan.FromMinutes(2)] = 100
		};

		public IRateLimitedRequester Requester { get; private set; }
		public async Task InitializeAsync()
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

			await Task.CompletedTask;
		}

		public Task DisposeAsync() => Task.CompletedTask;
	}
}