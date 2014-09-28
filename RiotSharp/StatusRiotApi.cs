// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatusRiotApi.cs" company="">
//
// </copyright>
// <summary>
//   Entry point for the status API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;

using Newtonsoft.Json;

using RiotSharp.StatusEndpoint;

namespace RiotSharp
{
    /// <summary>
    /// Entry point for the status API.
    /// </summary>
    public class StatusRiotApi
    {
        /// <summary>
        /// The status root url.
        /// </summary>
        private const string StatusRootUrl = "/shards";

        /// <summary>
        /// The region url.
        /// </summary>
        private const string RegionUrl = "/{0}";

        /// <summary>
        /// The root domain.
        /// </summary>
        private const string RootDomain = "status.leagueoflegends.com";

        /// <summary>
        /// The requester.
        /// </summary>
        private readonly Requester requester;

        /// <summary>
        /// The instance.
        /// </summary>
        private static StatusRiotApi instance;

        /// <summary>
        /// Get the instance of StatusRiotApi.
        /// </summary>
        /// <returns>The instance of StatusRiotApi.</returns>
        public static StatusRiotApi GetInstance()
        {
            return instance ?? (instance = new StatusRiotApi());
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="StatusRiotApi"/> class from being created.
        /// </summary>
        private StatusRiotApi()
        {
            requester = Requester.Instance;
        }

        /// <summary>
        /// Get the list of shards synchronously.
        /// </summary>
        /// <returns>A list of shards.</returns>
        public List<Shard> GetShards()
        {
            var json = requester.CreateRequest(StatusRootUrl, RootDomain);
            return JsonConvert.DeserializeObject<List<Shard>>(json);
        }

        /// <summary>
        /// Get the list of shards asynchronously.
        /// </summary>
        /// <returns>A list of shards.</returns>
        public async Task<List<Shard>> GetShardsAsync()
        {
            var json = await requester.CreateRequestAsync(StatusRootUrl, RootDomain);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<Shard>>(json));
        }

        /// <summary>
        /// Get shard status synchronously.
        /// Returns the data available on the status.leagueoflegends.com website for the given region.
        /// </summary>
        /// <param name="region">
        /// Region for which to check the status.
        /// </param>
        /// <returns>
        /// A shard status object containing different information regarding the shard.
        /// </returns>
        public ShardStatus GetShardStatus(Region region)
        {
            var json =
                requester.CreateRequest(StatusRootUrl + string.Format(RegionUrl, region), RootDomain);
            return JsonConvert.DeserializeObject<ShardStatus>(json);
        }

        /// <summary>
        /// Get shard status asynchronously.
        /// Returns the data available on the status.leagueoflegends.com website for the given region.
        /// </summary>
        /// <param name="region">
        /// Region for which to check the status.
        /// </param>
        /// <returns>
        /// A shard status object containing different information regarding the shard.
        /// </returns>
        public async Task<ShardStatus> GetShardStatusAsync(Region region)
        {
            var json = await
                requester.CreateRequestAsync(StatusRootUrl + string.Format(RegionUrl, region), RootDomain);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ShardStatus>(json));
        }
    }
}
