using System.Text.Json;
using RiotSharpNET8.Caching;
using RiotSharpNET8.Endpoints.Interfaces.Static;
using RiotSharpNET8.Endpoints.StaticDataEndpoint.ReforgedRune.Cache;
using RiotSharpNET8.Http.Interfaces;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.ReforgedRune
{
    /// <summary>
    /// Implementation of <see cref="IStaticReforgedRuneEndpoint"/>, inherits from <see cref="StaticEndpointBase"/>
    /// </summary>
    /// <seealso cref="StaticEndpointBase" />
    /// <seealso cref="IStaticReforgedRuneEndpoint" />
    public class StaticReforgedRuneEndpoint : StaticEndpointBase, IStaticReforgedRuneEndpoint
    {
        private const string ReforgedRunesDataKey = "runesReforged";
        private const string ReforgdRunesCacheKey = "reforged-runes";

        /// <inheritdoc />
        public StaticReforgedRuneEndpoint(IRiotRequester riotRequester, ICache cache, TimeSpan? slidingExpirationTime)
           : base(riotRequester, cache, slidingExpirationTime) { }

        /// <inheritdoc />
        public StaticReforgedRuneEndpoint(IRiotRequester riotRequester, ICache cache)
            : this(riotRequester, cache, null) { }

        /// <inheritdoc />
        public async Task<List<ReforgedRunePathStatic>> GetAllAsync(string version, Language language = Language.en_US)
        {
            var cacheKey = ReforgdRunesCacheKey + language + language + version;
            var wrapper = cache.Get<string, ReforgedRuneListStaticWrapper>(cacheKey);
            if (wrapper != null && wrapper.Validate(language, version))
            {
                return wrapper.ReforgedRunes;
            }
            var json = await RiotRequester.CreateGetRequestAsync(Host, CreateUrl(version, language, ReforgedRunesDataKey)).ConfigureAwait(false);
            var reforgedRunes = JsonSerializer.Deserialize<List<ReforgedRunePathStatic>>(json); //JsonConvert.DeserializeObject<List<ReforgedRunePathStatic>>(json);
            cache.Add(cacheKey, new ReforgedRuneListStaticWrapper(language, version, reforgedRunes), SlidingExpirationTime);
            return reforgedRunes;
        }
    }
}
