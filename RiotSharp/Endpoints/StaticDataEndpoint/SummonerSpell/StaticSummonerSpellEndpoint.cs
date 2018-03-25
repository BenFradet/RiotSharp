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
        private const string SummonerSpellsUrl = "summoner-spells";
        private const string SummonerSpellsCacheKey = "summoner-spells";
        private const string SummonerSpellByIdUrl = "summoner-spells/{0}";
        private const string SummonerSpellByIdCacheKey = "summoner-spell";

        public StaticSummonerSpellEndpoint(IRateLimitedRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            :base(requester, cache, slidingExpirationTime) { }

        public StaticSummonerSpellEndpoint(IRateLimitedRequester requester, ICache cache)
            : this(requester, cache, null) { }

        public async Task<SummonerSpellListStatic> GetSummonerSpellsAsync(Region region,
            SummonerSpellData summonerSpellData = SummonerSpellData.All, Language language = Language.en_US,
            string version = null)
        {
            var cacheKey = SummonerSpellsCacheKey + region + summonerSpellData + language + version;
            var wrapper = cache.Get<string, SummonerSpellListStaticWrapper>(cacheKey);
            if (wrapper != null && wrapper.Language == language && wrapper.SummonerSpellData == summonerSpellData)
            {
                return wrapper.SummonerSpellListStatic;
            }
            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + SummonerSpellsUrl, region,
                new List<string>
                {
                    $"locale={language}",
                    summonerSpellData == SummonerSpellData.Basic ?
                        null : string.Format(TagsParameter, summonerSpellData.ToString().ToLower()),
                    version == null ? null : $"version={version}"
                }).ConfigureAwait(false);
            var spells = JsonConvert.DeserializeObject<SummonerSpellListStatic>(json);
            wrapper = new SummonerSpellListStaticWrapper(spells, language, summonerSpellData);
            cache.Add(cacheKey, wrapper, SlidingExpirationTime);
            return wrapper.SummonerSpellListStatic;
        }

        public async Task<SummonerSpellStatic> GetSummonerSpellAsync(Region region, int summonerSpellId,
            SummonerSpellData summonerSpellData = SummonerSpellData.All, Language language = Language.en_US, 
            string version = null)
        {
            var cacheKey = SummonerSpellByIdCacheKey + region + summonerSpellId + summonerSpellData + language + version;
            var wrapper = cache.Get<string, SummonerSpellStaticWrapper>(cacheKey);
            if (wrapper != null && wrapper.SummonerSpellData == summonerSpellData && wrapper.Language == language)
            {
                return wrapper.SummonerSpellStatic;
            }
            var listWrapper = cache.Get<string, SummonerSpellListStaticWrapper>(SummonerSpellsCacheKey);
            if (listWrapper != null && listWrapper.SummonerSpellData == summonerSpellData
                && listWrapper.Language == language)
            {
                return listWrapper.SummonerSpellListStatic.SummonerSpells.ContainsKey(summonerSpellId.ToString()) ?
                    listWrapper.SummonerSpellListStatic.SummonerSpells[summonerSpellId.ToString()] : null;
            }
            var json = await requester.CreateGetRequestAsync(
                StaticDataRootUrl + string.Format(SummonerSpellByIdUrl, summonerSpellId), region,
                new List<string>
                {
                    $"locale={language}",
                    summonerSpellData == SummonerSpellData.Basic ?
                        null : string.Format(TagsParameter, summonerSpellData.ToString().ToLower()),
                    version == null ? null : $"version={version}"
                }).ConfigureAwait(false);
            var spell = JsonConvert.DeserializeObject<SummonerSpellStatic>(json);
            cache.Add(cacheKey, new SummonerSpellStaticWrapper(spell, language, summonerSpellData), SlidingExpirationTime);
            return spell;
        }
    }
}
