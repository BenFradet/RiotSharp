using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Endpoints.StaticDataEndpoint.Champion.Cache;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Champion
{
    public class StaticChampionEndpoint : StaticEndpointBase, IStaticChampionEndpoint
    {
        private const string ChampionsUrl = "champions";
        private const string ChampionByIdUrl = "champions/{0}";
        private const string ChampionsCacheKey = "champions";
        private const string ChampionByIdCacheKey = "champion";

        public StaticChampionEndpoint(IRateLimitedRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(requester, cache, slidingExpirationTime) { }

        public StaticChampionEndpoint(IRateLimitedRequester requester, ICache cache)
            : this(requester, cache, null) { }

        public async Task<ChampionListStatic> GetChampionsAsync(Region region,
            ChampionData championData = ChampionData.All, Language language = Language.en_US, string version = null)
        {
            var cacheKey = ChampionsCacheKey + region + championData + language + version;
            var wrapper = cache.Get<string, ChampionListStaticWrapper>(cacheKey);
            if (wrapper != null && language == wrapper.Language && championData == wrapper.ChampionData)
            {
                return wrapper.ChampionListStatic;
            }
            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + ChampionsUrl, region,
                new List<string>
                {
                    $"locale={language}",
                    championData == ChampionData.Basic ? null : string.Format(TagsParameter, championData.ToString().ToLower()),
                    version == null ? null : $"version={version}"
                }).ConfigureAwait(false);
            var champs = JsonConvert.DeserializeObject<ChampionListStatic>(json);
            wrapper = new ChampionListStaticWrapper(champs, language, championData);
            cache.Add(cacheKey, wrapper, SlidingExpirationTime);
            return wrapper.ChampionListStatic;
        }

        public async Task<ChampionStatic> GetChampionAsync(Region region, int championId,
            ChampionData championData = ChampionData.All, Language language = Language.en_US, string version = null)
        {
            var cacheKey = ChampionsCacheKey + region + championId + championData + language + version;
            var wrapper = cache.Get<string, ChampionStaticWrapper>(cacheKey);
            if (wrapper != null && wrapper.Language == language && wrapper.ChampionData == championData)
            {
                return wrapper.ChampionStatic;
            }
            var listWrapper = cache.Get<string, ChampionListStaticWrapper>(ChampionsCacheKey);
            if (listWrapper != null && listWrapper.Language == language &&
                listWrapper.ChampionData == championData)
            {
                return listWrapper.ChampionListStatic.Champions.Values.FirstOrDefault(c => c.Id == championId);
            }
            var json = await requester.CreateGetRequestAsync(
                StaticDataRootUrl + string.Format(ChampionByIdUrl, championId), region,
                new List<string>
                {
                    $"locale={language}",
                    championData == ChampionData.Basic ? null : string.Format(TagsParameter, championData.ToString().ToLower()),
                    version == null ? string.Empty : $"version={version}"
                }).ConfigureAwait(false);
            var champ = JsonConvert.DeserializeObject<ChampionStatic>(json);
            cache.Add(cacheKey, new ChampionStaticWrapper(champ, language, championData), SlidingExpirationTime);
            return champ;
        }
    }
}
