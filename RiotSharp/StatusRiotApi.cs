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
            if (instance == null)
            {
                instance = new StatusRiotApi();
            }
            return instance;
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
            return await Task.Factory.StartNew<List<Shard>>(() => JsonConvert.DeserializeObject<List<Shard>>(json));
        }

        /// <summary>
        /// Get shard status synchronously.
        /// Returns the data available on the status.leagueoflegends.com website for the given region.
        /// </summary>
        /// <param name="region">Region for which to check the status.</param>
        /// <returns>A shard status object containing different information regarding the shard.</returns>
        public ShardStatus GetShardStatus(Region region)
        {
            var json =
                requester.CreateRequest(StatusRootUrl + string.Format(RegionUrl, region.ToString()), RootDomain);
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
            var json = await
                requester.CreateRequestAsync(StatusRootUrl + string.Format(RegionUrl, region.ToString()), RootDomain);
            return await Task.Factory.StartNew<ShardStatus>(() => JsonConvert.DeserializeObject<ShardStatus>(json));
        }
    }
}
