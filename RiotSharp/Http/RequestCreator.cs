using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using RiotSharp.Http.Interfaces;
using RiotSharp.Http.Maps;
using RiotSharp.Misc;

namespace RiotSharp.Http
{
    public class RequestCreator : IRequestCreator
    {
        private readonly string apiKey;
        private readonly IRequestContentSerializer contentSerializer;

        public RequestCreator(string apiKey, IRequestContentSerializer contentSerializer)
        {
            this.apiKey = apiKey;
            this.contentSerializer = contentSerializer;
        }

        public HttpRequestMessage CreateGetRequest(Region region, string apiEndpoint, List<string> addedArguments, bool useHttps = true)
        {
            var url = BuildUrl(region, apiEndpoint, addedArguments, useHttps);
            return new HttpRequestMessage(HttpMethod.Get, url);
        }

        public HttpRequestMessage CreatePostRequest<T>(Region region, string apiEndpoint, T body, List<string> addedArguments, bool useHttps)
        {
            var url = BuildUrl(region, apiEndpoint, addedArguments, useHttps);
            return new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = contentSerializer.Serialize(body)
                //Content = new StringContent(body, Encoding.UTF8, "application/json"),
            };
        }

        public HttpRequestMessage CreatePutRequest<T>(Region region, string apiEndpoint, T body,
            List<string> addedArguments, bool useHttps)
        {
            var url = BuildUrl(region, apiEndpoint, addedArguments, useHttps);
            return new HttpRequestMessage(HttpMethod.Put, url)
            {
                Content = contentSerializer.Serialize(body)
            };
        }


        private string BuildUrl(Region region, string apiEndpoint, List<string> addedArguments, bool useHttps)
        {
            var scheme = useHttps ? "https" : "http";
            var domain = RegionPlatformMap.GetPlatformDomain(region);
            var arguments = BuildArgumentString(addedArguments);

            return $"{scheme}://{domain}{apiEndpoint}?{arguments}";
        }

        private string BuildArgumentString(IEnumerable<string> arguments)
            => string.Join("&", arguments.Concat(GetApiKeyParameter()).Where(IsNotEmpty));

        private IEnumerable<string> GetApiKeyParameter()
            => new[] { $"api_key={apiKey}" };

        private static bool IsNotEmpty(string argument)
            => argument != string.Empty;
    }
}
