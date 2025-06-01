using System.Text.Json;
using RiotSharpNET8.Caching;
using RiotSharpNET8.Endpoints.Interfaces.Static;
using RiotSharpNET8.Endpoints.StaticDataEndpoint.Rune.Cache;
using RiotSharpNET8.Http.Interfaces;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Rune
{
    /// <summary>
    /// Implementation of <see cref="IStaticRuneEndpoint"/>, inherits from <see cref="StaticEndpointBase"/>
    /// </summary>
    /// <seealso cref="StaticEndpointBase" />
    /// <seealso cref="IStaticRuneEndpoint" />
    public class StaticRuneEndpoint : StaticEndpointBase, IStaticRuneEndpoint
    {
        private const string RunesDataKey = "rune";
        private const string RunesCacheKey = "runes";

        /// <inheritdoc />
        public StaticRuneEndpoint(IRiotRequester riotRequester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(riotRequester, cache, slidingExpirationTime) { }

        /// <inheritdoc />
        public StaticRuneEndpoint(IRiotRequester riotRequester, ICache cache)
            : this(riotRequester, cache, null) { }

        /// <inheritdoc />
        public async Task<RuneListStatic> GetAllAsync(string version, Language language = Language.en_US)
        {
            var cacheKey = RunesCacheKey + language + language + version;
            var wrapper = cache.Get<string, RuneListStaticWrapper>(cacheKey);
            if (wrapper != null && language == wrapper.Language && version == wrapper.Version)
            {
                return wrapper.RuneListStatic;
            }
            var json = await RiotRequester.CreateGetRequestAsync(Host, CreateUrl(version, language, RunesDataKey)).ConfigureAwait(false);
            var runes = JsonSerializer.Deserialize<RuneListStatic>(json); //JsonConvert.DeserializeObject<RuneListStatic>(json);
            wrapper = new RuneListStaticWrapper(runes, language, version);
            cache.Add(cacheKey, wrapper, SlidingExpirationTime);
            return wrapper.RuneListStatic;
        }
    }
}
