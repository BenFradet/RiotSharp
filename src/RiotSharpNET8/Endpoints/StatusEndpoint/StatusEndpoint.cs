using System.Text.Json;
using RiotSharpNET8.Endpoints.Interfaces;
using RiotSharpNET8.Http.Interfaces;
using RiotSharpNET8.Misc;

namespace RiotSharpNET8.Endpoints.StatusEndpoint
{
    /// <summary>
    /// Implementation of <see cref="IStatusEndpoint"/>
    /// </summary>
    /// <seealso cref="RiotSharp.Interfaces.IStatusEndpoint" />
    public class StatusEndpoint : IStatusEndpoint
    {
        private const string StatusRootUrl = "/lol/status/v3/shard-data";

        private readonly IRiotRequester _riotRequester;

        public StatusEndpoint(IRiotRequester riotRequester)
        {
            _riotRequester = riotRequester;
        }

        #region Public Methods      

        /// <inheritdoc />
        public async Task<ShardStatus> GetShardStatusAsync(Region region)
        {
            var json = await _riotRequester.CreateGetRequestAsync(StatusRootUrl, region).ConfigureAwait(false);

            return JsonSerializer.Deserialize<ShardStatus>(json); //JsonConvert.DeserializeObject<ShardStatus>(json);
        }

        #endregion
    }
}
