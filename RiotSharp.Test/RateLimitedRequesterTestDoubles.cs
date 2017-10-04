using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using RiotSharp.Http;
using RiotSharp.Http.Interfaces;

namespace RiotSharp.Test
{
    class RateLimitedRequesterTestDoubles
    {
        public static IRateLimitedRequester Real(string apiKey, IDictionary<TimeSpan, int> rateLimits)
        {
            var serializer = new RequestContentSerializer();
            var deserializer = new ResponseDeserializer();
            var requestCreator = new RequestCreator(apiKey, serializer);
            var httpClient = new HttpClient();
            var failedRequestHandler = new FailedRequestHandler();
            var client = new RequestClient(httpClient, failedRequestHandler);
            var basicRequester = new Requester(client, requestCreator, deserializer);
            var rateLimitProvider = new RateLimitProvider(rateLimits);

            return new RateLimitedRequester(basicRequester, rateLimitProvider);
        }

        public static IRateLimitedRequester Real(string apiKey)
        {
            var rateLimits = new Dictionary<TimeSpan, int> { { new TimeSpan(1, 0, 0), 10 } };

            return Real(apiKey, rateLimits);
        }
    }
}
