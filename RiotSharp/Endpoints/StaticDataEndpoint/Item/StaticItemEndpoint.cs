using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Endpoints.StaticDataEndpoint.Item.Cache;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Item
{
    /// <summary>
    /// Implementation of <see cref="IStaticItemEndpoint"/>, inherits from <see cref="StaticEndpointBase"/>
    /// </summary>
    /// <seealso cref="RiotSharp.Endpoints.StaticDataEndpoint.StaticEndpointBase" />
    /// <seealso cref="RiotSharp.Endpoints.Interfaces.Static.IStaticItemEndpoint" />
    public class StaticItemEndpoint : StaticEndpointBase, IStaticItemEndpoint
    {
        private const string ItemsDataKey = "item";
        private const string ItemsCacheKey = "items";

        /// <summary>
        /// Initializes a new instance of the <see cref="StaticItemEndpoint"/> class.
        /// </summary>
        /// <param name="requester">The requester.</param>
        /// <param name="cache">The cache.</param>
        /// <param name="slidingExpirationTime">The sliding expiration time.</param>
        /// <inheritdoc />
        public StaticItemEndpoint(IRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(requester, cache, slidingExpirationTime) { }

        /// <inheritdoc />
        public StaticItemEndpoint(IRequester requester, ICache cache)
            : this(requester, cache, null) { }

        /// <inheritdoc />
        public async Task<ItemListStatic> GetAllAsync(string version, Language language = Language.en_US)
        {
            var cacheKey = ItemsCacheKey + language + version;
            var wrapper = cache.Get<string, ItemListStaticWrapper>(cacheKey);
            if (wrapper != null && language == wrapper.Language && version == wrapper.Version)
            {
                return wrapper.ItemListStatic;
            }
            var json = await requester.CreateGetRequestAsync(Host, CreateUrl(version, language, ItemsDataKey)).ConfigureAwait(false);
            var items = JsonConvert.DeserializeObject<ItemListStatic>(json);
            wrapper = new ItemListStaticWrapper(items, language, version);
            cache.Add(cacheKey, wrapper, SlidingExpirationTime);
            return wrapper.ItemListStatic;
        }
    }
}
