using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Endpoints.StaticDataEndpoint.Map.Cache;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Map
{
    /// <summary>
    /// Implementation of <see cref="IStaticMapEndpoint"/>, inherits from <see cref="StaticEndpointBase"/>
    /// </summary>
    /// <seealso cref="RiotSharp.Endpoints.StaticDataEndpoint.StaticEndpointBase" />
    /// <seealso cref="RiotSharp.Endpoints.Interfaces.Static.IStaticMapEndpoint" />
    public class StaticMapEndpoint : StaticEndpointBase, IStaticMapEndpoint
    {
        private const string MapsDataKey = "map";
        private const string MapsCacheKey = "maps";

        /// <inheritdoc />
        public StaticMapEndpoint(IRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(requester, cache, slidingExpirationTime) { }

        /// <inheritdoc />
        public StaticMapEndpoint(IRequester requester, ICache cache)
            : this(requester, cache, null) { }

        /// <inheritdoc />
        public async Task<List<MapStatic>> GetAllAsync(string version, Language language = Language.en_US)
        {
            var cacheKey = MapsCacheKey + language + version;
            var wrapper = cache.Get<string, MapsStaticWrapper>(cacheKey);
            if (wrapper != null && wrapper.Language == language && wrapper.Version == version)
            {
                return wrapper.MapsStatic.Data.Values.ToList();
            }

            var json = await requester.CreateGetRequestAsync(Host, CreateUrl(version, language, MapsDataKey)).ConfigureAwait(false);
            var maps = JsonConvert.DeserializeObject<MapsStatic>(json);

            cache.Add(cacheKey, new MapsStaticWrapper(maps, language, version), SlidingExpirationTime);

            return maps.Data.Values.ToList();
        }
    }
}
