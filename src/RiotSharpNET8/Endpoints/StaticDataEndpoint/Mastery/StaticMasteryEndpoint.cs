using System.Text.Json;
using RiotSharpNET8.Caching;
using RiotSharpNET8.Endpoints.Interfaces.Static;
using RiotSharpNET8.Endpoints.StaticDataEndpoint.Mastery.Cache;
using RiotSharpNET8.Http.Interfaces;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Mastery
{
    /// <summary>
    /// Implementation of <see cref="IStaticMasteryEndpoint"/>, inherits from <see cref="StaticEndpointBase"/>
    /// </summary>
    /// <seealso cref="StaticEndpointBase" />
    /// <seealso cref="IStaticMasteryEndpoint" />
    public class StaticMasteryEndpoint : StaticEndpointBase, IStaticMasteryEndpoint
    {
        private const string MasteriesDataKey = "mastery";
        private const string MasteriesCacheKey = "masteries";

        /// <inheritdoc />
        public StaticMasteryEndpoint(IRiotRequester riotRequester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(riotRequester, cache, slidingExpirationTime) { }

        /// <inheritdoc />
        public StaticMasteryEndpoint(IRiotRequester riotRequester, ICache cache)
            : this(riotRequester, cache, null) { }

        /// <inheritdoc />
        public async Task<MasteryListStatic> GetAllAsync(string version, Language language = Language.en_US)
        {
            var cacheKey = MasteriesCacheKey + language + version;
            var wrapper = cache.Get<string, MasteryListStaticWrapper>(cacheKey);
            if (wrapper != null && language == wrapper.Language && version == wrapper.Version)
            {
                return wrapper.MasteryListStatic;
            }
            var json = await RiotRequester.CreateGetRequestAsync(Host, CreateUrl(version, language, MasteriesDataKey)).ConfigureAwait(false);
            var masteries = JsonSerializer.Deserialize<MasteryListStatic>(json); //JsonConvert.DeserializeObject<MasteryListStatic>(json);
            wrapper = new MasteryListStaticWrapper(masteries, language, version);
            cache.Add(cacheKey, wrapper, SlidingExpirationTime);
            return wrapper.MasteryListStatic;
        }
    }
}
