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
        private const string MasteriesDataKey = "mastery";
        private const string MasteriesCacheKey = "masteries";

        public StaticMasteryEndpoint(IRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(requester, cache, slidingExpirationTime) { }

        public StaticMasteryEndpoint(IRequester requester, ICache cache)
            : this(requester, cache, null) { }

        public async Task<MasteryListStatic> GetMasteriesAsync(string version, Language language = Language.en_US)
        {
            var cacheKey = MasteriesCacheKey + language + version;
            var wrapper = cache.Get<string, MasteryListStaticWrapper>(cacheKey);
            if (wrapper != null && language == wrapper.Language && version == wrapper.Version)
            {
                return wrapper.MasteryListStatic;
            }
            var json = await requester.CreateGetRequestAsync(CreateUrl(version, language, MasteriesDataKey)).ConfigureAwait(false);
            var masteries = JsonConvert.DeserializeObject<MasteryListStatic>(json);
            wrapper = new MasteryListStaticWrapper(masteries, language, version);
            cache.Add(cacheKey, wrapper, SlidingExpirationTime);
            return wrapper.MasteryListStatic;
        }
    }
}
