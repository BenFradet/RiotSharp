using Newtonsoft.Json;
using RiotSharp.StatusEndpoint;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotSharp
{
    /// <summary>
    /// Entry point for the status API.
    /// </summary>
    public class StatusRiotApi : IStatusRiotApi
    {
        private const string StatusRootUrl = "/shards";

        private const string RegionUrl = "/{0}";

        private const string RootDomain = "status.leagueoflegends.com";

        private Requester requester;

        private static StatusRiotApi instance;
        /// <summary>
        /// Get the instance of StatusRiotApi.
        /// </summary>
        /// <returns>The instance of StatusRiotApi.</returns>
        public static StatusRiotApi GetInstance()
        {
            return instance ?? (instance = new StatusRiotApi());
        }

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
            var json = requester.CreateRequest(StatusRootUrl, RootDomain, null, false);
            return JsonConvert.DeserializeObject<List<Shard>>(json);
        }

        /// <summary>
        /// Get the list of shards asynchronously.
        /// </summary>
        /// <returns>A list of shards.</returns>
        public async Task<List<Shard>> GetShardsAsync()
        {
            var json = await requester.CreateRequestAsync(StatusRootUrl, RootDomain, null, false);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<Shard>>(json));
        }

        /// <summary>
        /// Get shard status synchronously.
        /// Returns the data available on the status.leagueoflegends.com website for the given region.
        /// </summary>
        /// <param name="region">Region for which to check the status.</param>
        /// <returns>A shard status object containing different information regarding the shard.</returns>
        public ShardStatus GetShardStatus(Region region)
        {
            var json = requester.CreateRequest(StatusRootUrl + string.Format(RegionUrl, region.ToString()),
                RootDomain, null, false);
            return JsonConvert.DeserializeObject<ShardStatus>(json);
        }

        /// <summary>
        /// Get shard status asynchronously.
        /// Returns the data available on the status.leagueoflegends.com website for the given region.
        /// </summary>
        /// <param name="region">Region for which to check the status.</param>
        /// <returns>A shard status object containing different information regarding the shard.</returns>
        public async Task<ShardStatus> GetShardStatusAsync(Region region)
        {
            var json = await requester.CreateRequestAsync(StatusRootUrl + string.Format(RegionUrl, region.ToString()),
                RootDomain, null, false);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ShardStatus>(json));
        }
    }
}
