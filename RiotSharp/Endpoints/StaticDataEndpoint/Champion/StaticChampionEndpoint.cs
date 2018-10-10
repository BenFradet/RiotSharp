using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Endpoints.StaticDataEndpoint.Champion.Cache;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Champion
{
    /// <summary>
    /// Implementation of IStaticChampionEndpoint, inherits from <see cref="StaticEndpointBase"/>
    /// </summary>
    /// <seealso cref="RiotSharp.Endpoints.StaticDataEndpoint.StaticEndpointBase" />
    /// <seealso cref="RiotSharp.Endpoints.Interfaces.Static.IStaticChampionEndpoint" />
    public class StaticChampionEndpoint : StaticEndpointBase, IStaticChampionEndpoint
    {
        private const string ChampionByKeyUrl = CdnUrl + "{0}/data/{1}/champion/{2}.json";
        private const string ChampionsDataKey = "champion";
        private const string ChampionsFullDataKey = "championFull";
        private const string ChampionsCacheKey = "champions";
        private const string ChampionByIdCacheKey = "champion";

        /// <inheritdoc />
        public StaticChampionEndpoint(IRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(requester, cache, slidingExpirationTime) { }

        /// <inheritdoc />
        public StaticChampionEndpoint(IRequester requester, ICache cache)
            : this(requester, cache, null) { }

        /// <inheritdoc />
        public async Task<ChampionListStatic> GetAllAsync(string version, Language language = Language.en_US, bool fullData = true)
        {
            var cacheKey = ChampionsCacheKey + language + version;
            var wrapper = cache.Get<string, ChampionListStaticWrapper>(cacheKey);
            if (wrapper != null && language == wrapper.Language && version == wrapper.Version)
            {
                return wrapper.ChampionListStatic;
            }
            var json = await requester.CreateGetRequestAsync(Host, CreateUrl(version, language, fullData ? ChampionsFullDataKey : ChampionsDataKey)).ConfigureAwait(false);
            var champs = JsonConvert.DeserializeObject<ChampionListStatic>(json);
            wrapper = new ChampionListStaticWrapper(champs, language, version);
            cache.Add(cacheKey, wrapper, SlidingExpirationTime);
            return wrapper.ChampionListStatic;
        }

        /// <inheritdoc />
        public async Task<ChampionStatic> GetByKeyAsync(string key, string version, Language language = Language.en_US)
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
            var json = await requester.CreateGetRequestAsync(Host, string.Format(ChampionByKeyUrl, version, language, key)).ConfigureAwait(false);
            var championStandAlone = JsonConvert.DeserializeObject<ChampionStandAloneStatic>(json);
            cache.Add(cacheKey, new ChampionStaticWrapper(championStandAlone.Data.First().Value, language, version), SlidingExpirationTime);
            return championStandAlone.Data.First().Value;
        }
    }
}
