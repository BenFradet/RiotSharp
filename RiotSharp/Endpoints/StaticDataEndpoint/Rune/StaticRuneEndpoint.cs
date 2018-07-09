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
        private const string RunesDataKey = "rune";
        private const string RunesCacheKey = "runes";

        public StaticRuneEndpoint(IRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(requester, cache, slidingExpirationTime) { }

        public StaticRuneEndpoint(IRequester requester, ICache cache)
            : this(requester, cache, null) { }

        public async Task<RuneListStatic> GetRunesAsync(string version, Language language = Language.en_US)
        {
            var cacheKey = RunesCacheKey + language + language + version;
            var wrapper = cache.Get<string, RuneListStaticWrapper>(cacheKey);
            if (wrapper != null && language == wrapper.Language && version == wrapper.Version)
            {
                return wrapper.RuneListStatic;
            }
            var json = await requester.CreateGetRequestAsync(CreateUrl(version, language, RunesDataKey)).ConfigureAwait(false);
            var runes = JsonConvert.DeserializeObject<RuneListStatic>(json);
            wrapper = new RuneListStaticWrapper(runes, language, version);
            cache.Add(cacheKey, wrapper, SlidingExpirationTime);
            return wrapper.RuneListStatic;
        }
    }
}
