using Newtonsoft.Json;
using RiotSharp.StatusEndpoint;
using System.Collections.Generic;
using System.Threading.Tasks;
using RiotSharp.Misc;

namespace RiotSharp
{
    public class StatusRiotApi : IStatusRiotApi
    {
        #region Private Fields
        
        private const string StatusRootUrl = "/lol/status/v3/shard-data";

        private const string RegionSubdomain = "{0}.";

        private const string RootDomain = "api.riotgames.com";

        private Requester requester;

        private static StatusRiotApi instance;

        #endregion

        /// <summary>
        /// Get the instance of StatusRiotApi.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <returns>The instance of StatusRiotApi.</returns>
        public static StatusRiotApi GetInstance(string apiKey)
        {
            if (instance == null ||
                Requesters.StatusApiRequester == null ||
                apiKey != Requesters.StatusApiRequester.ApiKey)
            {
                instance = new StatusRiotApi(apiKey);
            }
            return instance;
        }

        private StatusRiotApi(string apiKey)
        {
            Requesters.StatusApiRequester = new Requester(apiKey);
            requester = Requesters.StatusApiRequester;
        }

        public ShardStatus GetShardStatus(Platform platform)
        {
            var json = requester.CreateGetRequest(StatusRootUrl,
                string.Format(RegionSubdomain, platform.ToString()) + RootDomain, null, true);

            return JsonConvert.DeserializeObject<ShardStatus>(json);
        }

        public async Task<ShardStatus> GetShardStatusAsync(Platform platform)
        {
            var json = await requester.CreateGetRequestAsync(StatusRootUrl,
                string.Format(RegionSubdomain, platform.ToString()) + RootDomain, null, true);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ShardStatus>(json));
        }
    }
}
