using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Endpoints.StaticDataEndpoint.ReforgedRune.Cache;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.StaticDataEndpoint.ReforgedRune
{
    /// <summary>
    /// Implementation of <see cref="IStaticReforgedRuneEndpoint"/>, inherits from <see cref="StaticEndpointBase"/>
    /// </summary>
    /// <seealso cref="RiotSharp.Endpoints.StaticDataEndpoint.StaticEndpointBase" />
    /// <seealso cref="RiotSharp.Endpoints.Interfaces.Static.IStaticReforgedRuneEndpoint" />
    public class StaticReforgedRuneEndpoint : StaticEndpointBase, IStaticReforgedRuneEndpoint
    {
        private const string ReforgedRunesDataKey = "runesReforged";
        private const string ReforgdRunesCacheKey = "reforged-runes";

        /// <inheritdoc />
        public StaticReforgedRuneEndpoint(IRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
           : base(requester, cache, slidingExpirationTime) { }

        /// <inheritdoc />
        public StaticReforgedRuneEndpoint(IRequester requester, ICache cache)
            : this(requester, cache, null) { }

        /// <inheritdoc />
        public async Task<List<ReforgedRunePathStatic>> GetAllAsync(string version, Language language = Language.en_US)
        {
            var cacheKey = ReforgdRunesCacheKey + language + language + version;
            var wrapper = cache.Get<string, ReforgedRuneListStaticWrapper>(cacheKey);
            if (wrapper != null && wrapper.Validate(language, version))
            {
                return wrapper.ReforgedRunes;
            }
            var json = await requester.CreateGetRequestAsync(Host, CreateUrl(version, language, ReforgedRunesDataKey)).ConfigureAwait(false);
            var reforgedRunes = JsonConvert.DeserializeObject<List<ReforgedRunePathStatic>>(json);
            cache.Add(cacheKey, new ReforgedRuneListStaticWrapper(language, version, reforgedRunes), SlidingExpirationTime);
            return reforgedRunes;
        }
    }
}
