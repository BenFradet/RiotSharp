using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Endpoints.StaticDataEndpoint.Mastery.Cache;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Mastery
{
    /// <summary>
    /// Implementation of <see cref="IStaticMasteryEndpoint"/>, inherits from <see cref="StaticEndpointBase"/>
    /// </summary>
    /// <seealso cref="RiotSharp.Endpoints.StaticDataEndpoint.StaticEndpointBase" />
    /// <seealso cref="RiotSharp.Endpoints.Interfaces.Static.IStaticMasteryEndpoint" />
    public class StaticMasteryEndpoint : StaticEndpointBase, IStaticMasteryEndpoint
    {
        private const string MasteriesDataKey = "mastery";
        private const string MasteriesCacheKey = "masteries";

        /// <inheritdoc />
        public StaticMasteryEndpoint(IRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(requester, cache, slidingExpirationTime) { }

        /// <inheritdoc />
        public StaticMasteryEndpoint(IRequester requester, ICache cache)
            : this(requester, cache, null) { }

        /// <inheritdoc />
        public async Task<MasteryListStatic> GetAllAsync(string version, Language language = Language.en_US)
        {
            var cacheKey = MasteriesCacheKey + language + version;
            var wrapper = cache.Get<string, MasteryListStaticWrapper>(cacheKey);
            if (wrapper != null && language == wrapper.Language && version == wrapper.Version)
            {
                return wrapper.MasteryListStatic;
            }
            var json = await requester.CreateGetRequestAsync(Host, CreateUrl(version, language, MasteriesDataKey)).ConfigureAwait(false);
            var masteries = JsonConvert.DeserializeObject<MasteryListStatic>(json);
            wrapper = new MasteryListStaticWrapper(masteries, language, version);
            cache.Add(cacheKey, wrapper, SlidingExpirationTime);
            return wrapper.MasteryListStatic;
        }
    }
}
