using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Endpoints.StaticDataEndpoint.SummonerSpell.Cache;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.StaticDataEndpoint.SummonerSpell
{
    /// <summary>
    /// Implementation of <see cref="IStaticSummonerSpellEndpoint"/>, inherits from <see cref="StaticEndpointBase"/>
    /// </summary>
    /// <seealso cref="RiotSharp.Endpoints.StaticDataEndpoint.StaticEndpointBase" />
    /// <seealso cref="RiotSharp.Endpoints.Interfaces.Static.IStaticSummonerSpellEndpoint" />
    public class StaticSummonerSpellEndpoint : StaticEndpointBase, IStaticSummonerSpellEndpoint
    {
        private const string SummonerSpellsDataKey = "summoner";
        private const string SummonerSpellsCacheKey = "summoner-spells";

        /// <inheritdoc />
        public StaticSummonerSpellEndpoint(IRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            :base(requester, cache, slidingExpirationTime) { }

        /// <inheritdoc />
        public StaticSummonerSpellEndpoint(IRequester requester, ICache cache)
            : this(requester, cache, null) { }

        /// <inheritdoc />
        public async Task<SummonerSpellListStatic> GetAllAsync(string version, Language language = Language.en_US)
        {
            var cacheKey = SummonerSpellsCacheKey + language + version;
            var wrapper = cache.Get<string, SummonerSpellListStaticWrapper>(cacheKey);
            if (wrapper != null && wrapper.Language == language && wrapper.Version == version)
            {
                return wrapper.SummonerSpellListStatic;
            }
            var json = await requester.CreateGetRequestAsync(Host, CreateUrl(version, language, SummonerSpellsDataKey)).ConfigureAwait(false);
            var spells = JsonConvert.DeserializeObject<SummonerSpellListStatic>(json);
            wrapper = new SummonerSpellListStaticWrapper(spells, language, version);
            cache.Add(cacheKey, wrapper, SlidingExpirationTime);
            return wrapper.SummonerSpellListStatic;
        }
    }
}
