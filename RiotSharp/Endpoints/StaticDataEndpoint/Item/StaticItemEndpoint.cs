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
        private const string ItemsUrl = "items";
        private const string ItemByIdUrl = "items/{0}";
        private const string ItemsCacheKey = "items";
        private const string ItemByIdCacheKey = "item";

        public StaticItemEndpoint(IRateLimitedRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(requester, cache, slidingExpirationTime) { }

        public StaticItemEndpoint(IRateLimitedRequester requester, ICache cache)
            : this(requester, cache, null) { }

        public async Task<ItemListStatic> GetItemsAsync(Region region, ItemData itemData = ItemData.All,
            Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, ItemListStaticWrapper>(ItemsCacheKey);
            if (wrapper != null && language == wrapper.Language && itemData == wrapper.ItemData)
            {
                return wrapper.ItemListStatic;
            }
            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + ItemsUrl, region,
                new List<string>
                {
                    $"locale={language}",
                    itemData == ItemData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, itemData.ToString().ToLower())
                }).ConfigureAwait(false);
            var items = JsonConvert.DeserializeObject<ItemListStatic>(json);
            wrapper = new ItemListStaticWrapper(items, language, itemData);
            cache.Add(ItemsCacheKey, wrapper, SlidingExpirationTime);
            return wrapper.ItemListStatic;
        }

        public async Task<ItemStatic> GetItemAsync(Region region, int itemId, ItemData itemData = ItemData.All,
            Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, ItemStaticWrapper>(ItemByIdCacheKey + itemId);
            if (wrapper != null && wrapper.Language == language && wrapper.ItemData == itemData)
            {
                return wrapper.ItemStatic;
            }
            var listWrapper = cache.Get<String, ItemListStaticWrapper>(ItemsCacheKey);
            if (listWrapper != null && listWrapper.Language == language && listWrapper.ItemData == itemData)
            {
                return listWrapper.ItemListStatic.Items.ContainsKey(itemId) ?
                    listWrapper.ItemListStatic.Items[itemId] : null;
            }
            var json = await requester.CreateGetRequestAsync(
                StaticDataRootUrl + string.Format(ItemByIdUrl, itemId), region,
                new List<string>
                {
                    $"locale={language}",
                    itemData == ItemData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, itemData.ToString().ToLower())
                }).ConfigureAwait(false);
            var item = JsonConvert.DeserializeObject<ItemStatic>(json);
            cache.Add(ItemByIdCacheKey + itemId, new ItemStaticWrapper(item, language, itemData), SlidingExpirationTime);
            return item;
        }
    }
}
