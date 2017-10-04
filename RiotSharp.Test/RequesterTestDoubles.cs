using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using RiotSharp.Http;
using RiotSharp.Http.Interfaces;

namespace RiotSharp.Test
{
    public class RequesterTestDoubles
    {
        public static IRequester Real(string apiKey)
        {
            var serializer = new RequestContentSerializer();
            var deserializer = new ResponseDeserializer();
            var requestCreator = new RequestCreator(apiKey, serializer);

            var httpClient = new HttpClient();
            var failedRequestHandler = new FailedRequestHandler();

            var client = new RequestClient(httpClient, failedRequestHandler);

            return new Requester(client, requestCreator, deserializer);
        }
    }
}
