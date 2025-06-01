using System.Text.Json;
using RiotSharpNET8.Caching;
using RiotSharpNET8.Endpoints.Interfaces.Static;
using RiotSharpNET8.Endpoints.StaticDataEndpoint.Realm.Cache;
using RiotSharpNET8.Http.Interfaces;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.Realm
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="StaticEndpointBase" />
    /// <seealso cref="IStaticRealmEndpoint" />
    public class StaticRealmEndpoint : StaticEndpointBase, IStaticRealmEndpoint
    {
        private const string RealmsUrl = "/realms/{0}.json";
        private const string RealmsCacheKey = "realms";

        /// <inheritdoc />
        public StaticRealmEndpoint(IRiotRequester riotRequester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(riotRequester, cache, slidingExpirationTime) { }

        /// <inheritdoc />
        public StaticRealmEndpoint(IRiotRequester riotRequester, ICache cache)
            : this(riotRequester, cache, null) { }

        /// <inheritdoc />
        public async Task<RealmStatic> GetAllAsync(Region region)
        {
            var cacheKey = RealmsCacheKey + region;
            var wrapper = cache.Get<string, RealmStaticWrapper>(cacheKey);
            if (wrapper != null)
            {
                return wrapper.RealmStatic;
            }

            var json = await RiotRequester.CreateGetRequestAsync(Host, string.Format(RealmsUrl, region.ToString().ToLower())).ConfigureAwait(false);
            var realm = JsonSerializer.Deserialize<RealmStatic>(json); //JsonConvert.DeserializeObject<RealmStatic>(json);

            cache.Add(cacheKey, new RealmStaticWrapper(realm), SlidingExpirationTime);

            return realm;
        }
    }
}
