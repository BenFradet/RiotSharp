using Newtonsoft.Json;
using RiotSharp.Http;
using RiotSharp.Http.Interfaces;
using RiotSharp.Interfaces;
using System.Threading.Tasks;
using RiotSharp.Misc;
using System;
using RiotSharp.Endpoints.StatusEndpoint;

namespace RiotSharp
{
    /// <summary>
    /// Implementation of <see cref="IStatusRiotApi"/>
    /// </summary>
    /// <seealso cref="RiotSharp.Interfaces.IStatusRiotApi" />
    public class StatusRiotApi : IStatusRiotApi
    {
        #region Private Fields
        
        private const string StatusRootUrl = "/lol/status/v3/shard-data";

        private const string PlatformSubdomain = "{0}.";

        private const string RootDomain = "api.riotgames.com";

        private readonly IRequester _requester;

        private static StatusRiotApi _instance;

        #endregion

        /// <summary>
        /// Get the instance of StatusRiotApi.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <returns>The instance of StatusRiotApi.</returns>
        public static StatusRiotApi GetInstance(string apiKey)
        {
            if (_instance == null)
                _instance = new StatusRiotApi(apiKey);
            return _instance;
        }

        private StatusRiotApi(string apiKey)
        {
            Requesters.StatusApiRequester = new Requester(apiKey);
            _requester = Requesters.StatusApiRequester;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusRiotApi"/> class.
        /// </summary>
        /// <param name="requester">The requester.</param>
        /// <exception cref="ArgumentNullException">requester</exception>
        public StatusRiotApi(IRequester requester)
        {
            this._requester = requester ?? throw new ArgumentNullException(nameof(requester));
        }

        #region Public Methods      

        /// <inheritdoc />
        public async Task<ShardStatus> GetShardStatusAsync(Region region)
        {
            var json = await _requester.CreateGetRequestAsync(StatusRootUrl, region).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<ShardStatus>(json);
        }

        #endregion
    }
}
