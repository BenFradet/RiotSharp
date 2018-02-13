using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Http.Interfaces;
using System;

namespace RiotSharp.Endpoints.StaticDataEndpoint
{
    public abstract class StaticEndpointBase : IStaticEndpoint
    {
        protected const string StaticDataRootUrl = "/lol/static-data/v3/";
        protected const string IdUrl = "/{0}";
        protected const string TagsParameter = "tags={0}";

        protected IRateLimitedRequester requester;

        protected ICache cache;
        protected TimeSpan SlidingExpirationTime;
        public readonly TimeSpan DefaultSlidingExpirationTime = new TimeSpan(1, 0, 0);

        protected StaticEndpointBase(IRateLimitedRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
        {
            this.requester = requester;
            this.cache = cache;
            this.SlidingExpirationTime = slidingExpirationTime ?? DefaultSlidingExpirationTime;
        }

        protected StaticEndpointBase(IRateLimitedRequester requester, ICache cache)
            : this(requester, cache, null) { }
    }
}
