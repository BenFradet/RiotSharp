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
    public class StaticRealmEndpoint : StaticEndpointBase, IStaticRealmEndpoint
    {
        private const string RealmsUrl = "realms";
        private const string RealmsCacheKey = "realms";

        public StaticRealmEndpoint(IRateLimitedRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
            : base(requester, cache, slidingExpirationTime) { }

        public StaticRealmEndpoint(IRateLimitedRequester requester, ICache cache)
            : this(requester, cache, null) { }

        public async Task<RealmStatic> GetRealmAsync(Region region)
        {
            var wrapper = cache.Get<string, RealmStaticWrapper>(RealmsCacheKey);
            if (wrapper != null)
            {
                return wrapper.RealmStatic;
            }

            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + RealmsUrl, region).ConfigureAwait(false);
            var realm = JsonConvert.DeserializeObject<RealmStatic>(json);

            cache.Add(RealmsCacheKey, new RealmStaticWrapper(realm), SlidingExpirationTime);

            return realm;
        }
    }
}
