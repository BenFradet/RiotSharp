using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Version
{
    public class StaticVersionEndpoint : StaticEndpointBase, IStaticVersionEndpoint
    {
        private const string VersionsUrl = "versions";
        private const string VersionsCacheKey = "versions";

        public StaticVersionEndpoint(IRateLimitedRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(requester, cache, slidingExpirationTime) { }

        public StaticVersionEndpoint(IRateLimitedRequester requester, ICache cache)
            : this(requester, cache, null) { }

        public async Task<List<string>> GetVersionsAsync(Region region)
        {
            var wrapper = cache.Get<string, List<string>>(VersionsCacheKey);
            if (wrapper != null)
            {
                return wrapper;
            }

            var json =
                await requester.CreateGetRequestAsync(StaticDataRootUrl + VersionsUrl, region).ConfigureAwait(false);
            var version = JsonConvert.DeserializeObject<List<string>>(json);

            cache.Add(VersionsCacheKey, version, SlidingExpirationTime);

            return version;
        }
    }
}
