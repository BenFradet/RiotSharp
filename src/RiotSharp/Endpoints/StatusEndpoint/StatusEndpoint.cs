using Newtonsoft.Json;
using RiotSharp.Http;
using RiotSharp.Http.Interfaces;
using RiotSharp.Interfaces;
using System.Threading.Tasks;
using RiotSharp.Misc;
using System;
using RiotSharp.Endpoints.StatusEndpoint;
using RiotSharp.Endpoints.Interfaces;

namespace RiotSharp.Endpoints.StatusEndpoint
{
    /// <summary>
    /// Implementation of <see cref="IStatusEndpoint"/>
    /// </summary>
    /// <seealso cref="RiotSharp.Interfaces.IStatusEndpoint" />
    public class StatusEndpoint : IStatusEndpoint
    {
        private const string StatusRootUrl = "/lol/status/v3/shard-data";

        private readonly IRequester _requester;

        public StatusEndpoint(IRequester requester)
        {
            _requester = requester;
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
