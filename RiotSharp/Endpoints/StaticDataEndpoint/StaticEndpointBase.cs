using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;

namespace RiotSharp.Endpoints.StaticDataEndpoint
{
    public abstract class StaticEndpointBase : IStaticEndpoint
    {
        protected const string RootUrl = "http://ddragon.leagueoflegends.com/cdn/";
        protected const string DefaultUrlPattern = "http://ddragon.leagueoflegends.com/cdn/{0}/data/{1}/{3}.json";
        protected IRequester requester;

        protected ICache cache;
        protected TimeSpan SlidingExpirationTime;
        public readonly TimeSpan DefaultSlidingExpirationTime = new TimeSpan(1, 0, 0);

        protected StaticEndpointBase(IRequester requester, ICache cache, TimeSpan? slidingExpirationTime)
        {
            this.requester = requester;
            this.cache = cache;
            this.SlidingExpirationTime = slidingExpirationTime ?? DefaultSlidingExpirationTime;
        }

        protected StaticEndpointBase(IRequester requester, ICache cache)
            : this(requester, cache, null) { }

        protected string CreateUrl(string version, Language language, string dataKey)
        {
            return String.Format(DefaultUrlPattern, version, language, dataKey);
        }
    }
}
