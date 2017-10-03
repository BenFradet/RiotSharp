using Newtonsoft.Json;
using RiotSharp.Http;
using RiotSharp.Http.Interfaces;
using RiotSharp.Interfaces;
using RiotSharp.StatusEndpoint;
using System.Threading.Tasks;
using RiotSharp.Misc;
using System;
using System.Net.Http;

namespace RiotSharp
{
    public partial class StatusRiotApi : IStatusRiotApi
    {
        private const string StatusRootUrl = "/lol/status/v3/shard-data";

        private readonly IRequesterAlt requester;

        public StatusRiotApi(IRequesterAlt requester)
        {
            this.requester = requester;
        }

        public ShardStatus GetShardStatus(Region region)
        {
            return requester.Get<ShardStatus>(StatusRootUrl, region);
        }

        public async Task<ShardStatus> GetShardStatusAsync(Region region)
        {
            return await requester.GetAsync<ShardStatus>(StatusRootUrl, region);
        }
    }

    public partial class StatusRiotApi
    {
        private static StatusRiotApi instance;

        /// <summary>
        /// Get the instance of StatusRiotApi.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <returns>The instance of StatusRiotApi.</returns>
        public static StatusRiotApi GetInstance(string apiKey)
        {
            return instance ?? (instance = new StatusRiotApi(apiKey));
        }

        private StatusRiotApi(string apiKey)
        {
            var client = new RequestClient(new HttpClient(), new FailedRequestHandler());
            var requestCreator = new RequestCreator(apiKey);
            var deserializer = new ResponseDeserializer();

            requester = new RequesterAlt(client, requestCreator, deserializer);
            Requesters.StatusApiRequesterAlt = (RequesterAlt) requester;
        }
    }
}
