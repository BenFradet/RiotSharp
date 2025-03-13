using RiotSharpNET8.Http.Interfaces;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Http.Requesters
{
	/// <summary>
	/// Needs work.
	/// </summary>
	internal class StaticDataRequester : RequesterBase, IStaticDataRequester
	{
		public StaticDataRequester(string apiKey, IHttpRequester httpRequester)
			: base(apiKey, httpRequester) { }

		public async Task<string> CreateGetRequestAsync(string relativeUrl, Region region,
			List<string>? queryParameters = null, bool useHttps = true)
		{
			var host = "GetPlatformHost(region);";
			var request = PrepareRequest(host, relativeUrl, queryParameters, useHttps, HttpMethod.Get);
			var response = await SendMessageAsync(request).ConfigureAwait(false);
			return await GetResponseContentAsync(response).ConfigureAwait(false);
		}

		/// <inheritdoc />
		public async Task<string> CreateGetRequestAsync(string host, string relativeUrl, 
			List<string>? queryParameters = null, bool useHttps = true)
		{
			var request = PrepareRequest(host, relativeUrl, queryParameters, useHttps, HttpMethod.Get);
			var response = await SendMessageAsync(request).ConfigureAwait(false);
			return await GetResponseContentAsync(response).ConfigureAwait(false);
		}

		protected override string PlatformDomain => "ddragon.leagueoflegends.com";
		public override void HandleRequestFailure(HttpResponseMessage response)
		{
			throw new NotImplementedException();
		}
	}
}
