using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Endpoints.StaticDataEndpoint.Map.Cache;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Map
{
    public class StaticMapEndpoint : StaticEndpointBase, IStaticMapEndpoint
    {
        private const string MapsUrl = "maps";
        private const string MapsCacheKey = "maps";

        public StaticMapEndpoint(IRateLimitedRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(requester, cache, slidingExpirationTime) { }

        public StaticMapEndpoint(IRateLimitedRequester requester, ICache cache)
            : this(requester, cache, null) { }

        public async Task<List<MapStatic>> GetMapsAsync(Region region, Language language = Language.en_US,
            string version = null)
        {
            var cacheKey = MapsCacheKey + region + language + version;
            var wrapper = cache.Get<string, MapsStaticWrapper>(cacheKey);
            if (wrapper != null && wrapper.Language == language && wrapper.Version == version)
            {
                return wrapper.MapsStatic.Data.Values.ToList();
            }

            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + MapsUrl, region,
                new List<string> {
                    $"locale={language}",
                    version == null ? null : $"version={version}"
                }).ConfigureAwait(false);
            var maps = JsonConvert.DeserializeObject<MapsStatic>(json);

            cache.Add(cacheKey, new MapsStaticWrapper(maps, language, version), SlidingExpirationTime);

            return maps.Data.Values.ToList();
        }
    }
}
