using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Endpoints.StaticDataEndpoint.Mastery.Cache;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Mastery
{
    public class StaticMasteryEndpoint : StaticEndpointBase, IStaticMasteryEndpoint
    {
        private const string MasteriesUrl = "masteries";
        private const string MasteryByIdUrl = "masteries/{0}";
        private const string MasteriesCacheKey = "masteries";
        private const string MasteryByIdCacheKey = "mastery";

        public StaticMasteryEndpoint(IRateLimitedRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(requester, cache, slidingExpirationTime) { }

        public StaticMasteryEndpoint(IRateLimitedRequester requester, ICache cache)
            : this(requester, cache, null) { }

        public async Task<MasteryListStatic> GetMasteriesAsync(Region region,
            MasteryData masteryData = MasteryData.All, Language language = Language.en_US, string version = null)
        {
            var cacheKey = MasteriesCacheKey + region + masteryData + language + version;
            var wrapper = cache.Get<string, MasteryListStaticWrapper>(cacheKey);
            if (wrapper != null && language == wrapper.Language && masteryData == wrapper.MasteryData)
            {
                return wrapper.MasteryListStatic;
            }
            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + MasteriesUrl, region,
                new List<string>
                {
                    $"locale={language}",
                    masteryData == MasteryData.Basic ? string.Empty : string.Format(TagsParameter, masteryData.ToString().ToLower()),
                    version == null ? null : $"version={version}"
                }).ConfigureAwait(false);
            var masteries = JsonConvert.DeserializeObject<MasteryListStatic>(json);
            wrapper = new MasteryListStaticWrapper(masteries, language, masteryData);
            cache.Add(cacheKey, wrapper, SlidingExpirationTime);
            return wrapper.MasteryListStatic;
        }

        public async Task<MasteryStatic> GetMasteryAsync(Region region, int masteryId,
            MasteryData masteryData = MasteryData.All, Language language = Language.en_US, string version = null)
        {
            var cacheKey = MasteryByIdCacheKey + region + masteryId + masteryData + language + version;
            var wrapper = cache.Get<string, MasteryStaticWrapper>(cacheKey);
            if (wrapper != null && wrapper.Language == language && wrapper.MasteryData == masteryData)
            {
                return wrapper.MasteryStatic;
            }
            var listWrapper = cache.Get<string, MasteryListStaticWrapper>(MasteriesCacheKey);
            if (listWrapper != null && listWrapper.Language == language && listWrapper.MasteryData == masteryData)
            {
                return listWrapper.MasteryListStatic.Masteries.ContainsKey(masteryId)
                    ? listWrapper.MasteryListStatic.Masteries[masteryId] : null;
            }
            var json = await requester.CreateGetRequestAsync(
                StaticDataRootUrl + string.Format(MasteryByIdUrl, masteryId), region,
                new List<string>
                {
                    $"locale={language}",
                    masteryData == MasteryData.Basic ? string.Empty : string.Format(TagsParameter, masteryData.ToString().ToLower()),
                    version == null ? null : $"version={version}"
                }).ConfigureAwait(false);
            var mastery = JsonConvert.DeserializeObject<MasteryStatic>(json);
            cache.Add(cacheKey, new MasteryStaticWrapper(mastery, language, masteryData), SlidingExpirationTime);
            return mastery;
        }
    }
}
