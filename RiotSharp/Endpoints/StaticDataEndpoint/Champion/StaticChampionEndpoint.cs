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
        private const string ChampionsDataKey = "champions";
        private const string ChampionByIdUrl = "champions/{0}";
        private const string ChampionsCacheKey = "champions";
        private const string ChampionByIdCacheKey = "champion";

        public StaticChampionEndpoint(IRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(requester, cache, slidingExpirationTime) { }

        public StaticChampionEndpoint(IRequester requester, ICache cache)
            : this(requester, cache, null) { }

        public async Task<ChampionListStatic> GetChampionsAsync(string version, Language language = Language.en_US)
        {
            var cacheKey = ChampionsCacheKey + language + version;
            var wrapper = cache.Get<string, ChampionListStaticWrapper>(cacheKey);
            if (wrapper != null && language == wrapper.Language && version == wrapper.Version)
            {
                return wrapper.ChampionListStatic;
            }
            var json = await requester.CreateGetRequestAsync(CreateUrl(version, language, ChampionsDataKey)).ConfigureAwait(false);
            var champs = JsonConvert.DeserializeObject<ChampionListStatic>(json);
            wrapper = new ChampionListStaticWrapper(champs, language, version);
            cache.Add(cacheKey, wrapper, SlidingExpirationTime);
            return wrapper.ChampionListStatic;
        }

        public async Task<ChampionStatic> GetChampionAsync(string key, string version, Language language = Language.en_US)
        {
            var cacheKey = ChampionsCacheKey + key + language + version;
            var wrapper = cache.Get<string, ChampionStaticWrapper>(cacheKey);
            if (wrapper != null && wrapper.Language == language)
            {
                return wrapper.ChampionStatic;
            }
            var listWrapper = cache.Get<string, ChampionListStaticWrapper>(ChampionsCacheKey);
            if (listWrapper != null && listWrapper.Language == language && version == listWrapper.Version)
            {
                return listWrapper.ChampionListStatic.Champions.Values.FirstOrDefault(c => c.Key == key);
            }
            var json = await requester.CreateGetRequestAsync(RootUrl + $"{version}/data/{language}/champion/{key}.json").ConfigureAwait(false);
            var champ = JsonConvert.DeserializeObject<ChampionStatic>(json);
            cache.Add(cacheKey, new ChampionStaticWrapper(champ, language, version), SlidingExpirationTime);
            return champ;
        }
    }
}
