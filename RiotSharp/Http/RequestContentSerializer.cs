using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotSharp.Http.Interfaces;

namespace RiotSharp.Http
{
    public class RequestContentSerializer : IRequestContentSerializer
    {
        public HttpContent Serialize(object body)
        {
            var json = JsonConvert.SerializeObject(body, Settings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        public async Task<HttpContent> SerializeAsync(object body)
        {
            var json = await Task.Run(() => JsonConvert.SerializeObject(body, Settings)); 
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };
    }
}
