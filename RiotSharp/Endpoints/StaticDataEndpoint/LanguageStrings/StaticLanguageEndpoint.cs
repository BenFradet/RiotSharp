using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Endpoints.StaticDataEndpoint.LanguageStrings.Cache;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.StaticDataEndpoint.LanguageStrings
{
    public class StaticLanguageEndpoint : StaticEndpointBase, IStaticLanguageEndpoint
    {
        private const string LanguageStringsUrl = "language-strings";
        private const string LanguageStringsCacheKey = "language-strings";

        private const string LanguagesUrl = "languages";
        private const string LanguagesCacheKey = "languages";

        public StaticLanguageEndpoint(IRateLimitedRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(requester, cache, slidingExpirationTime) { }

        public StaticLanguageEndpoint(IRateLimitedRequester requester, ICache cache)
            : this(requester, cache, null) { }

        #region Language Strings       

        public async Task<LanguageStringsStatic> GetLanguageStringsAsync(Region region,
            Language language = Language.en_US, string version = null)
        {
            var cacheKey = LanguageStringsCacheKey + region + language + version;
            var wrapper = cache.Get<string, LanguageStringsStaticWrapper>(cacheKey);
            if (wrapper != null && wrapper.Language == language && wrapper.Version == version)
            {
                return wrapper.LanguageStringsStatic;
            }

            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + LanguageStringsUrl, region,
                new List<string> {
                    $"locale={language}",
                    version == null ? null : $"version={version}"
                }).ConfigureAwait(false);
            var languageStrings = JsonConvert.DeserializeObject<LanguageStringsStatic>(json);

            cache.Add(cacheKey, new LanguageStringsStaticWrapper(languageStrings, language, version), 
                SlidingExpirationTime);

            return languageStrings;
        }
        #endregion

        #region Languages

        public async Task<List<Language>> GetLanguagesAsync(Region region)
        {
            var cacheKey = LanguagesCacheKey + region;
            var wrapper = cache.Get<string, List<Language>>(cacheKey);
            if (wrapper != null)
            {
                return wrapper;
            }

            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + LanguagesUrl, region).ConfigureAwait(false);
            var languages = JsonConvert.DeserializeObject<List<Language>>(json);

            cache.Add(cacheKey, languages, SlidingExpirationTime);

            return languages;
        }
        #endregion
    }
}
