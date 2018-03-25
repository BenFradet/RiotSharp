using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Endpoints.StaticDataEndpoint.Rune.Cache;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Rune
{
    public class StaticRuneEndpoint : StaticEndpointBase, IStaticRuneEndpoint
    {
        private const string RunesUrl = "runes";
        private const string RuneByIdUrl = "runes/{0}";
        private const string RunesCacheKey = "runes";
        private const string RuneByIdCacheKey = "rune";

        public StaticRuneEndpoint(IRateLimitedRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(requester, cache, slidingExpirationTime) { }

        public StaticRuneEndpoint(IRateLimitedRequester requester, ICache cache)
            : this(requester, cache, null) { }

        public async Task<RuneListStatic> GetRunesAsync(Region region, RuneData runeData = RuneData.All,
            Language language = Language.en_US, string version = null)
        {
            var cacheKey = RunesCacheKey + region + runeData + language + language + version;
            var wrapper = cache.Get<string, RuneListStaticWrapper>(cacheKey);
            if (wrapper != null && !(language != wrapper.Language | runeData != wrapper.RuneData))
            {
                return wrapper.RuneListStatic;
            }
            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + RunesUrl, region,
                new List<string>
                {
                    $"locale={language}",
                    runeData == RuneData.Basic ? null : string.Format(TagsParameter, runeData.ToString().ToLower()),
                    version == null ? null : $"version={version}"
                }).ConfigureAwait(false);
            var runes = JsonConvert.DeserializeObject<RuneListStatic>(json);
            wrapper = new RuneListStaticWrapper(runes, language, runeData);
            cache.Add(cacheKey, wrapper, SlidingExpirationTime);
            return wrapper.RuneListStatic;
        }

        public async Task<RuneStatic> GetRuneAsync(Region region, int runeId, RuneData runeData = RuneData.All,
            Language language = Language.en_US, string version = null)
        {
            var cacheKey = RuneByIdCacheKey + region + runeId + runeData + language + language + version;
            var wrapper = cache.Get<string, RuneStaticWrapper>(cacheKey);
            if (wrapper != null && wrapper.Language == language && wrapper.RuneData == RuneData.All)
            {
                return wrapper.RuneStatic;
            }
            var listWrapper = cache.Get<string, RuneListStaticWrapper>(RunesCacheKey);
            if (listWrapper != null && listWrapper.Language == language && listWrapper.RuneData == runeData)
            {
                return listWrapper.RuneListStatic.Runes.ContainsKey(runeId) ?
                    listWrapper.RuneListStatic.Runes[runeId] : null;
            }
            var json = await requester.CreateGetRequestAsync(
                StaticDataRootUrl + string.Format(RuneByIdUrl, runeId), region,
                new List<string>
                {
                    $"locale={language}",
                    runeData == RuneData.Basic ? null : string.Format(TagsParameter, runeData.ToString().ToLower()),
                    version == null ? null : $"version={version}"
                }).ConfigureAwait(false);
            var rune = JsonConvert.DeserializeObject<RuneStatic>(json);
            cache.Add(cacheKey, new RuneStaticWrapper(rune, language, runeData), SlidingExpirationTime);
            return rune;
        }
    }
}
