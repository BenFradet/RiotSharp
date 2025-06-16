using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Endpoints.StaticDataEndpoint.Realm.Cache;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.StaticDataEndpoint.Realm
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="RiotSharp.Endpoints.StaticDataEndpoint.StaticEndpointBase" />
    /// <seealso cref="RiotSharp.Endpoints.Interfaces.Static.IStaticRealmEndpoint" />
    public class StaticRealmEndpoint : StaticEndpointBase, IStaticRealmEndpoint
    {
        private const string RealmsUrl = "/realms/{0}.json";
        private const string RealmsCacheKey = "realms";

        /// <inheritdoc />
        public StaticRealmEndpoint(IRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(requester, cache, slidingExpirationTime) { }

        /// <inheritdoc />
        public StaticRealmEndpoint(IRequester requester, ICache cache)
            : this(requester, cache, null) { }

        /// <inheritdoc />
        public async Task<RealmStatic> GetAllAsync(Region region)
        {
            var cacheKey = RealmsCacheKey + region;
            var wrapper = cache.Get<string, RealmStaticWrapper>(cacheKey);
            if (wrapper != null)
            {
                return wrapper.RealmStatic;
            }

            var json = await requester.CreateGetRequestAsync(Host, string.Format(RealmsUrl, region.ToString().ToLower())).ConfigureAwait(false);
            var realm = JsonConvert.DeserializeObject<RealmStatic>(json);

            cache.Add(cacheKey, new RealmStaticWrapper(realm), SlidingExpirationTime);

            return realm;
        }
    }
}
