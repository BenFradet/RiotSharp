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
        private const string VersionsCacheKey = "versions";

        public StaticVersionEndpoint(IRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(requester, cache, slidingExpirationTime) { }

        public StaticVersionEndpoint(IRequester requester, ICache cache)
            : this(requester, cache, null) { }

        public async Task<List<string>> GetAllAsync()
        {
            var cacheKey = VersionsCacheKey;
            var wrapper = cache.Get<string, List<string>>(cacheKey);
            if (wrapper != null)
            {
                return wrapper;
            }

            var json =
                await requester.CreateGetRequestAsync("https://ddragon.leagueoflegends.com/api/versions.json").ConfigureAwait(false);
            var version = JsonConvert.DeserializeObject<List<string>>(json);

            cache.Add(cacheKey, version, SlidingExpirationTime);

            return version;
        }
    }
}
