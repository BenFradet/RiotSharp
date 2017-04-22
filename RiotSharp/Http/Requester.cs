using RiotSharp.Http.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotSharp.Http
{
    /// <summary>
    /// A requester without a rate limiter.
    /// </summary>
    class Requester : RequesterBase, IRequester
    {
        internal Requester(string apiKey = "")
        {
            ApiKey = apiKey;
        }

        #region Public Methods
        
        public string CreateGetRequest(string relativeUrl, string rootDomain, List<string> addedArguments = null,
            bool useHttps = true)
        {
            this.rootDomain = rootDomain;
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, HttpMethod.Get);
            var result = string.Empty;
            var response = GetAsync(request).Result;
            return GetResponseContent(response);
        }

        public async Task<string> CreateGetRequestAsync(string relativeUrl, string rootDomain,
            List<string> addedArguments = null, bool useHttps = true)
        {
            this.rootDomain = rootDomain;
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, HttpMethod.Get);
            var response = GetAsync(request).Result;
            return await GetResponseContentAsync(response);
        }           

        #endregion    
    }
}
