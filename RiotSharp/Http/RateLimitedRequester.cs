using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;

namespace RiotSharp.Http
{
    public class RateLimitedRequester : IRateLimitedRequester
    {

        private readonly IRequester requester;
        private readonly IRateLimitProvider limitProvider;

        public RateLimitedRequester(IRequester requester, IRateLimitProvider limitProvider)
        {
            this.requester = requester;
            this.limitProvider = limitProvider;
        }

        public T Get<T>(string relativeUrl, Region region, List<string> addedArguments = null,
            bool useHttps = true)
        {
            limitProvider.GetLimiter(region).HandleRateLimit();
            return requester.Get<T>(relativeUrl, region, addedArguments, useHttps);
        }

        public async Task<T> GetAsync<T>(string relativeUrl, Region region, List<string> addedArguments = null,
            bool useHttps = true)
        {
            await limitProvider.GetLimiter(region).HandleRateLimitAsync();
            return await requester.GetAsync<T>(relativeUrl, region, addedArguments, useHttps);
        }

        public T Post<T>(string relativeUrl, Region region, object body,
            List<string> addedArguments = null, bool useHttps = true)
        {
            limitProvider.GetLimiter(region).HandleRateLimit();
            return requester.Post<T>(relativeUrl, region, body, addedArguments, useHttps);
        }

        public async Task<T> PostAsync<T>(string relativeUrl, Region region, object body,
            List<string> addedArguments = null, bool useHttps = true)
        {
            limitProvider.GetLimiter(region).HandleRateLimit();
            return await requester.PostAsync<T>(relativeUrl, region, body, addedArguments, useHttps);
        }

        public bool Put(string relativeUrl, Region region, object body,
            List<string> addedArguments = null, bool useHttps = true)
        {
            limitProvider.GetLimiter(region).HandleRateLimit();
            return requester.Put(relativeUrl, region, body, addedArguments, useHttps);
        }

        public async Task<bool> PutAsync(string relativeUrl, Region region, object body,
            List<string> addedArguments = null, bool useHttps = true)
        {
            limitProvider.GetLimiter(region).HandleRateLimit();
            return await requester.PutAsync(relativeUrl, region, body, addedArguments, useHttps);
        }
    }
}
