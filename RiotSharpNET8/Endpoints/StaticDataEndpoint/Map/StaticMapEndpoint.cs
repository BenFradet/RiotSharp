using System.Text.Json;
using RiotSharpNET8.Caching;
using RiotSharpNET8.Endpoints.Interfaces.Static;
using RiotSharpNET8.Endpoints.StaticDataEndpoint.Map.Cache;
using RiotSharpNET8.Http.Interfaces;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Map
{
    /// <summary>
    /// Implementation of <see cref="IStaticMapEndpoint"/>, inherits from <see cref="StaticEndpointBase"/>
    /// </summary>
    /// <seealso cref="StaticEndpointBase" />
    /// <seealso cref="IStaticMapEndpoint" />
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
            var maps = JsonSerializer.Deserialize<MapsStatic>(json); //JsonConvert.DeserializeObject<MapsStatic>(json);

            cache.Add(cacheKey, new MapsStaticWrapper(maps, language, version), SlidingExpirationTime);

            return maps.Data.Values.ToList();
        }
    }
}
