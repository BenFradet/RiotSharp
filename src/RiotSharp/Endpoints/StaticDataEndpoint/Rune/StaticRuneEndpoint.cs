using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Endpoints.StaticDataEndpoint.Rune.Cache;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Rune
{
    /// <summary>
    /// Implementation of <see cref="IStaticRuneEndpoint"/>, inherits from <see cref="StaticEndpointBase"/>
    /// </summary>
    /// <seealso cref="RiotSharp.Endpoints.StaticDataEndpoint.StaticEndpointBase" />
    /// <seealso cref="RiotSharp.Endpoints.Interfaces.Static.IStaticRuneEndpoint" />
    public class StaticRuneEndpoint : StaticEndpointBase, IStaticRuneEndpoint
    {
        private const string RunesDataKey = "rune";
        private const string RunesCacheKey = "runes";

        /// <inheritdoc />
        public StaticRuneEndpoint(IRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(requester, cache, slidingExpirationTime) { }

        /// <inheritdoc />
        public StaticRuneEndpoint(IRequester requester, ICache cache)
            : this(requester, cache, null) { }

        /// <inheritdoc />
        public async Task<RuneListStatic> GetAllAsync(string version, Language language = Language.en_US)
        {
            var cacheKey = RunesCacheKey + language + language + version;
            var wrapper = cache.Get<string, RuneListStaticWrapper>(cacheKey);
            if (wrapper != null && language == wrapper.Language && version == wrapper.Version)
            {
                return wrapper.RuneListStatic;
            }
            var json = await requester.CreateGetRequestAsync(Host, CreateUrl(version, language, RunesDataKey)).ConfigureAwait(false);
            var runes = JsonConvert.DeserializeObject<RuneListStatic>(json);
            wrapper = new RuneListStaticWrapper(runes, language, version);
            cache.Add(cacheKey, wrapper, SlidingExpirationTime);
            return wrapper.RuneListStatic;
        }
    }
}
