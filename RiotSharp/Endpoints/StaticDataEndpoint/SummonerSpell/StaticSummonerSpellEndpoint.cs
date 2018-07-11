using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Endpoints.StaticDataEndpoint.SummonerSpell.Cache;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.StaticDataEndpoint.SummonerSpell
{
    public class StaticSummonerSpellEndpoint : StaticEndpointBase, IStaticSummonerSpellEndpoint
    {
        private const string SummonerSpellsDataKey = "summoner";
        private const string SummonerSpellsCacheKey = "summoner-spells";

        public StaticSummonerSpellEndpoint(IRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            :base(requester, cache, slidingExpirationTime) { }

        public StaticSummonerSpellEndpoint(IRequester requester, ICache cache)
            : this(requester, cache, null) { }

        public async Task<SummonerSpellListStatic> GetAll(string version, Language language = Language.en_US)
        {
            var cacheKey = SummonerSpellsCacheKey + language + version;
            var wrapper = cache.Get<string, SummonerSpellListStaticWrapper>(cacheKey);
            if (wrapper != null && wrapper.Language == language && wrapper.Version == version)
            {
                return wrapper.SummonerSpellListStatic;
            }
            var json = await requester.CreateGetRequestAsync(CreateUrl(version, language, SummonerSpellsDataKey)).ConfigureAwait(false);
            var spells = JsonConvert.DeserializeObject<SummonerSpellListStatic>(json);
            wrapper = new SummonerSpellListStaticWrapper(spells, language, version);
            cache.Add(cacheKey, wrapper, SlidingExpirationTime);
            return wrapper.SummonerSpellListStatic;
        }
    }
}
