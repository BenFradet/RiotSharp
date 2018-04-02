using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Endpoints.StaticDataEndpoint.ReforgedRune.Cache;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.StaticDataEndpoint.ReforgedRune
{
    public class StaticReforgedRuneEndpoint : StaticEndpointBase, IStaticReforgedRuneEndpoint
    {
        private const string ReforgedRunesUrl = "reforged-runes";
        private const string ReforgedRuneByIdUrl = "reforged-runes/{0}";
        private const string ReforgdRunesCacheKey = "reforged-runes";
        private const string ReforgedRuneByIdCacheKey = "reforged-rune";

        private const string ReforgedRunePathsUrl = "reforged-rune-paths";
        private const string ReforgedRunePathByIdUrl = "reforged-rune-paths/{0}";
        private const string ReforgdRunePathsCacheKey = "reforged-rune-paths";
        private const string ReforgedRunePathByIdCacheKey = "reforged-rune-path";

        public StaticReforgedRuneEndpoint(IRateLimitedRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
           : base(requester, cache, slidingExpirationTime) { }

        public StaticReforgedRuneEndpoint(IRateLimitedRequester requester, ICache cache)
            : this(requester, cache, null) { }

        public async Task<ReforgedRuneStatic> GetReforgedRuneAsync(Region region, int reforgedRuneId, Language language = Language.en_US, string version = null)
        {
            var cacheKey = ReforgedRuneByIdCacheKey + region + language + language + version;
            var wrapper = cache.Get<string, ReforgedRuneStaticWrapper>(cacheKey);
            if (wrapper != null && wrapper.Validate(reforgedRuneId, language, version))
            {
                return wrapper.ReforgedRune;
            }
            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + string.Format(ReforgedRuneByIdUrl, reforgedRuneId), region,
                new List<string>
                {
                    $"locale={language}",
                    version == null ? null : $"version={version}"
                }).ConfigureAwait(false);
            var reforgedRune = JsonConvert.DeserializeObject<ReforgedRuneStatic>(json);
            cache.Add(cacheKey, new ReforgedRuneStaticWrapper(reforgedRuneId, language, version, reforgedRune), SlidingExpirationTime);
            return reforgedRune;
        }

        public async Task<List<ReforgedRuneStatic>> GetReforgedRunesAsync(Region region, Language language = Language.en_US, string version = null)
        {
            var cacheKey = ReforgdRunesCacheKey + region + language + language + version;
            var wrapper = cache.Get<string, ReforgedRuneListStaticWrapper>(cacheKey);
            if (wrapper != null && wrapper.Validate(language, version))
            {
                return wrapper.ReforgedRunes;
            }
            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + ReforgedRunesUrl, region,
                new List<string>
                {
                    $"locale={language}",
                    version == null ? null : $"version={version}"
                }).ConfigureAwait(false);
            var reforgedRunes = JsonConvert.DeserializeObject<List<ReforgedRuneStatic>>(json);
            cache.Add(cacheKey, new ReforgedRuneListStaticWrapper(language, version, reforgedRunes), SlidingExpirationTime);
            return reforgedRunes;
        }

        public async Task<ReforgedRunePathStatic> GetReforgedRunePathAsync(Region region, int reforgedRunePathId, Language language = Language.en_US, string version = null)
        {
            var cacheKey = ReforgedRunePathByIdCacheKey + region + language + language + version;
            var wrapper = cache.Get<string, ReforgedRunePathStaticWrapper>(cacheKey);
            if (wrapper != null && wrapper.Validate(reforgedRunePathId, language, version))
            {
                return wrapper.ReforgedRunePath;
            }
            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + string.Format(ReforgedRunePathByIdUrl, reforgedRunePathId), region,
                new List<string>
                {
                    $"locale={language}",
                    version == null ? null : $"version={version}"
                }).ConfigureAwait(false);
            var reforgedRunePath = JsonConvert.DeserializeObject<ReforgedRunePathStatic>(json);
            cache.Add(cacheKey, new ReforgedRunePathStaticWrapper(reforgedRunePathId, language, version, reforgedRunePath), SlidingExpirationTime);
            return reforgedRunePath;
        }

        public async Task<List<ReforgedRunePathStatic>> GetReforgedRunePathsAsync(Region region, Language language = Language.en_US, string version = null)
        {
            var cacheKey = ReforgdRunePathsCacheKey + region + language + language + version;
            var wrapper = cache.Get<string, ReforgedRunePathListStaticWrapper>(cacheKey);
            if (wrapper != null && wrapper.Validate(language, version))
            {
                return wrapper.ReforgedRunePaths;
            }
            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + ReforgedRunePathsUrl, region,
                new List<string>
                {
                    $"locale={language}",
                    version == null ? null : $"version={version}"
                }).ConfigureAwait(false);
            var reforgedRunePaths = JsonConvert.DeserializeObject<List<ReforgedRunePathStatic>>(json);
            cache.Add(cacheKey, new ReforgedRunePathListStaticWrapper(language, version, reforgedRunePaths), SlidingExpirationTime);
            return reforgedRunePaths;
        }
    }
}
