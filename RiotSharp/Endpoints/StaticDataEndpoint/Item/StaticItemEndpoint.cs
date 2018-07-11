using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Endpoints.StaticDataEndpoint;
using RiotSharp.Endpoints.StaticDataEndpoint.Item.Cache;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Item
{
    public class StaticItemEndpoint : StaticEndpointBase, IStaticItemEndpoint
    {
        private const string ItemsDataKey = "item";
        private const string ItemsCacheKey = "items";

        public StaticItemEndpoint(IRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(requester, cache, slidingExpirationTime) { }

        public StaticItemEndpoint(IRequester requester, ICache cache)
            : this(requester, cache, null) { }

        public async Task<ItemListStatic> GetAll(string version, Language language = Language.en_US)
        {
            var cacheKey = ItemsCacheKey + language + version;
            var wrapper = cache.Get<string, ItemListStaticWrapper>(cacheKey);
            if (wrapper != null && language == wrapper.Language && version == wrapper.Version)
            {
                return wrapper.ItemListStatic;
            }
            var json = await requester.CreateGetRequestAsync(CreateUrl(version, language, ItemsDataKey)).ConfigureAwait(false);
            var items = JsonConvert.DeserializeObject<ItemListStatic>(json);
            wrapper = new ItemListStaticWrapper(items, language, version);
            cache.Add(cacheKey, wrapper, SlidingExpirationTime);
            return wrapper.ItemListStatic;
        }
    }
}
