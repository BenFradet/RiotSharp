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

        private readonly IRequester requester;

        public StatusRiotApi(IRequester requester)
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
            var serializer = new RequestContentSerializer();
            var deserializer = new ResponseDeserializer();
            var requestCreator = new RequestCreator(apiKey, serializer);

            var httpClient = new HttpClient();
            var failedRequestHandler = new FailedRequestHandler();

            var client = new RequestClient(httpClient, failedRequestHandler);

            requester = new Requester(client, requestCreator, deserializer);
            Requesters.StatusApiRequester = (Requester) requester;
        }
    }
}
