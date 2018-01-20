using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.RunesEndpoint
{
    class RunesEndpoint : IRunesEndpoint
    {
        private const string PlatformRootUrl = "/lol/platform/v3";
        private const string RunesUrl = "/runes/by-summoner/{0}";

        private readonly IRateLimitedRequester _requester;

        public RunesEndpoint(IRateLimitedRequester requester)
        {
            _requester = requester;
        }

        public async Task<List<RunePage>> GetRunePagesAsync(Region region, long summonerId)
        {
            var json = await _requester.CreateGetRequestAsync(PlatformRootUrl + string.Format(RunesUrl, summonerId),
                region).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<RunePages>(json).Pages;
        }
    }
}
