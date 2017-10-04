using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;

namespace RiotSharp.Http
{
    /// <summary>
    /// An alternative requester without a rate limiter.
    /// </summary>
    public class Requester : IRequester
    {
        private readonly IRequestClient client;
        private readonly IRequestCreator requestCreator;
        private readonly IResponseDeserializer responseDeserializer;

        private static List<string> NoArguments() => new List<string>();

        public Requester(IRequestClient client, IRequestCreator requestCreator, IResponseDeserializer responseDeserializer)
        {
            this.client = client;
            this.requestCreator = requestCreator;
            this.responseDeserializer = responseDeserializer;
        }

        public T Get<T>(
            string relativeUrl,
            Region region,
            List<string> addedArguments = null,
            bool useHttps = true)
        {
            var arguments = addedArguments ?? NoArguments();
            var request = requestCreator.CreateGetRequest(region, relativeUrl, arguments, useHttps);
            var response = client.Get(request);
            return responseDeserializer.DeserializeTo<T>(response);
        }

        public async Task<T> GetAsync<T>(
            string relativeUrl,
            Region region,
            List<string> addedArguments = null,
            bool useHttps = true)
        {
            var arguments = addedArguments ?? NoArguments();
            var request = requestCreator.CreateGetRequest(region, relativeUrl, arguments, useHttps);
            var response = await client.GetAsync(request);
            return await responseDeserializer.DeserializeToAsync<T>(response);
        }

        public T Post<T>(string relativeUrl, Region region, object body,
            List<string> addedArguments = null, bool useHttps = true)
        {
            var arguments = addedArguments ?? NoArguments();
            var request = requestCreator.CreatePostRequest(region, relativeUrl, body, arguments, useHttps);
            var response = client.Post(request);
            return responseDeserializer.DeserializeTo<T>(response);
        }

        public async Task<T> PostAsync<T>(string relativeUrl, Region region, object body,
            List<string> addedArguments = null, bool useHttps = true)
        {
            var arguments = addedArguments ?? NoArguments();
            var request = requestCreator.CreatePostRequest(region, relativeUrl, body, arguments, useHttps);
            var response = await client.PostAsync(request);
            return await responseDeserializer.DeserializeToAsync<T>(response);
        }

        public bool Put(string relativeUrl, Region region, object body,
            List<string> addedArguments = null, bool useHttps = true)
        {
            var arguments = addedArguments ?? NoArguments();
            var request = requestCreator.CreatePostRequest(region, relativeUrl, body, arguments, useHttps);
            var response = client.Post(request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PutAsync(string relativeUrl, Region region, object body,
            List<string> addedArguments = null, bool useHttps = true)
        {
            var arguments = addedArguments ?? NoArguments();
            var request = requestCreator.CreatePutRequest(region, relativeUrl, body, arguments, useHttps);
            var response = await client.PostAsync(request);
            return response.IsSuccessStatusCode;
        }
    }
}
