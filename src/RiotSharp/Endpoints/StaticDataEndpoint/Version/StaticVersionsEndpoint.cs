using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Http.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Version
{
    /// <summary>
    /// Implementation of <see cref="IStaticVersionEndpoint"/>, inherits from <see cref="StaticEndpointBase"/>
    /// </summary>
    /// <seealso cref="RiotSharp.Endpoints.StaticDataEndpoint.StaticEndpointBase" />
    /// <seealso cref="RiotSharp.Endpoints.Interfaces.Static.IStaticVersionEndpoint" />
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
            var version = JsonConvert.DeserializeObject<List<string>>(json);

            cache.Add(cacheKey, version, SlidingExpirationTime);

            return version;
        }
    }
}
