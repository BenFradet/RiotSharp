using Microsoft.Extensions.Configuration;
using RiotSharp.Account.Endpoints;
using RiotSharp.Core.Http.Interfaces;
using RiotSharp.Core.Http.RateLimiting;
using RiotSharp.Core.Http.Requesters;

namespace RiotSharp.Account.Tests.Shared
{
	[CollectionDefinition("Shared fixture")]
	public class AccountFixtureCollection : ICollectionFixture<AccountTextFixture>
	{
		// This class has no code, and is never created. Its purpose is simply
		// to be the place to apply [CollectionDefinition] and all the
		// ICollectionFixture<> interfaces.
	}

	public class AccountTextFixture : IDisposable
	{
		private string? ApiKey { get; }
		
		private Dictionary<TimeSpan, int> RateLimits { get; } = new()
		{
			[TimeSpan.FromSeconds(1)] = 20,
			[TimeSpan.FromMinutes(2)] = 100
		};

		private IRateLimitedRequester Requester { get; }

		public RiotAccount RiotAccount { get; private set; }

		public AccountTextFixture()
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
			RiotAccount = new RiotAccount.Builder()
				.UseAccountEndpoint(new AccountEndpoint(Requester))
				.Build();
		}

		public void Dispose()
		{ }
	}
}