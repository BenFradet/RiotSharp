using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;

namespace RiotSharp.Endpoints.StaticDataEndpoint
{
    public abstract class StaticEndpointBase : IStaticEndpoint
    {
        internal const string Host = "ddragon.leagueoflegends.com";

        protected const string CdnUrl = "/cdn/";
        protected const string ApiUrl = "/api/";
        protected const string ResoureUrlPattern = CdnUrl + "{0}/data/{1}/{2}.json";

        protected bool useHttps;
        protected ICache cache;
        protected IRequester requester;
        protected TimeSpan SlidingExpirationTime;
        public readonly TimeSpan DefaultSlidingExpirationTime = new TimeSpan(1, 0, 0);

        protected StaticEndpointBase(IRequester requester, ICache cache, TimeSpan? slidingExpirationTime, bool useHttps = true)
        {
            this.requester = requester;
            this.cache = cache;
            this.useHttps = useHttps;

            this.SlidingExpirationTime = slidingExpirationTime ?? DefaultSlidingExpirationTime;   
        }

        protected StaticEndpointBase(IRequester requester, ICache cache)
            : this(requester, cache, null) { }

        protected string CreateUrl(string version, Language language, string dataKey)
        {
            return String.Format(ResoureUrlPattern, version, language, dataKey);
        }
    }
}
