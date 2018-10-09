using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;

namespace RiotSharp.Endpoints.StaticDataEndpoint
{
    /// <summary>
    /// Abstract base class which implements <see cref="IStaticEndpoint"/>
    /// </summary>
    /// <seealso cref="RiotSharp.Endpoints.Interfaces.Static.IStaticEndpoint" />
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

        /// <summary>
        /// Initializes a new instance of the <see cref="StaticEndpointBase"/> class.
        /// </summary>
        /// <param name="requester">The requester.</param>
        /// <param name="cache">The cache.</param>
        /// <param name="slidingExpirationTime">The sliding expiration time.</param>
        /// <param name="useHttps">if set to <c>true</c> [use HTTPS].</param>
        protected StaticEndpointBase(IRequester requester, ICache cache, TimeSpan? slidingExpirationTime, bool useHttps = true)
        {
            this.requester = requester;
            this.cache = cache;
            this.useHttps = useHttps;

            this.SlidingExpirationTime = slidingExpirationTime ?? DefaultSlidingExpirationTime;   
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StaticEndpointBase"/> class.
        /// </summary>
        /// <param name="requester">The requester.</param>
        /// <param name="cache">The cache.</param>
        protected StaticEndpointBase(IRequester requester, ICache cache)
            : this(requester, cache, null) { }

        /// <summary>
        /// Creates the URL.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <param name="language">The language.</param>
        /// <param name="dataKey">The data key.</param>
        protected string CreateUrl(string version, Language language, string dataKey)
        {
            return String.Format(ResoureUrlPattern, version, language, dataKey);
        }
    }
}
