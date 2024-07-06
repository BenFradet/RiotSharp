using System.Text.Json;
using RiotSharpNET8.Caching;
using RiotSharpNET8.Endpoints.Interfaces.Static;
using RiotSharpNET8.Http.Interfaces;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Version
{
    /// <summary>
    /// Implementation of <see cref="IStaticVersionEndpoint"/>, inherits from <see cref="StaticEndpointBase"/>
    /// </summary>
    /// <seealso cref="StaticEndpointBase" />
    /// <seealso cref="IStaticVersionEndpoint" />
    public class StaticVersionEndpoint : StaticEndpointBase, IStaticVersionEndpoint
    {
        private const string VersionsCacheKey = "versions";
        private const string VersionsUrl = ApiUrl + "versions.json";

        /// <inheritdoc />
        public StaticVersionEndpoint(IRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(requester, cache, slidingExpirationTime) { }

        /// <inheritdoc />
        public StaticVersionEndpoint(IRequester requester, ICache cache)
            : this(requester, cache, null) { }

        /// <inheritdoc />
        public async Task<List<string>> GetAllAsync()
        {
            var cacheKey = VersionsCacheKey;
            var wrapper = cache.Get<string, List<string>>(cacheKey);
            if (wrapper != null)
            {
                return wrapper;
            }

            var json =
                await requester.CreateGetRequestAsync(Host, VersionsUrl).ConfigureAwait(false);
            var version = JsonSerializer.Deserialize<List<string>>(json); //JsonConvert.DeserializeObject<List<string>>(json);

            cache.Add(cacheKey, version, SlidingExpirationTime);

            return version;
        }
    }
}
