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
        private const string LanguageStringsDataKey = "language";
        private const string LanguageStringsCacheKey = "language-strings";

        private const string LanguagesCacheKey = "languages";

        public StaticLanguageEndpoint(IRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(requester, cache, slidingExpirationTime) { }

        public StaticLanguageEndpoint(IRequester requester, ICache cache)
            : this(requester, cache, null) { }

        #region Language Strings
        public async Task<LanguageStringsStatic> GetLanguageStringsAsync(string version, Language language = Language.en_US)
        {
            var cacheKey = LanguageStringsCacheKey + language + version;
            var wrapper = cache.Get<string, LanguageStringsStaticWrapper>(cacheKey);
            if (wrapper != null && wrapper.Language == language && wrapper.Version == version)
            {
                return wrapper.LanguageStringsStatic;
            }

            var json = await requester.CreateGetRequestAsync(CreateUrl(version, language, LanguageStringsDataKey)).ConfigureAwait(false);
            var languageStrings = JsonConvert.DeserializeObject<LanguageStringsStatic>(json);

            cache.Add(cacheKey, new LanguageStringsStaticWrapper(languageStrings, language, version), 
                SlidingExpirationTime);

            return languageStrings;
        }
        #endregion

        #region Languages
        public async Task<List<Language>> GetLanguagesAsync()
        {
            var cacheKey = LanguagesCacheKey;
            var wrapper = cache.Get<string, List<Language>>(cacheKey);
            if (wrapper != null)
            {
                return wrapper;
            }

            var json = await requester.CreateGetRequestAsync(RootUrl + "languages.json").ConfigureAwait(false);
            var languages = JsonConvert.DeserializeObject<List<Language>>(json);

            cache.Add(cacheKey, languages, SlidingExpirationTime);

            return languages;
        }
        #endregion
    }
}
