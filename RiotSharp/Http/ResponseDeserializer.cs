using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotSharp.Http.Interfaces;

namespace RiotSharp.Http
{
    public class ResponseDeserializer : IResponseDeserializer
    {
        public async Task<T> DeserializeToAsync<T>(HttpResponseMessage message)
        {
            var json = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        public T DeserializeTo<T>(HttpResponseMessage message)
            => DeserializeToAsync<T>(message).Result;
    }
}
