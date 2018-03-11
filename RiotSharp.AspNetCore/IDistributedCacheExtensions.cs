using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;

namespace RiotSharp.AspNetCore
{
    internal static class IDistributedCacheExtensions
    {
        public static void SetJson(this IDistributedCache distributedCache, string key, object value, TimeSpan slidingExpiry)
        {
            var serializedValue = JsonConvert.SerializeObject(value);
            distributedCache.SetString(key.ToString(), serializedValue, new DistributedCacheEntryOptions
            {
                SlidingExpiration = slidingExpiry
            });
        }

        public static void SetJson(this IDistributedCache distributedCache, string key, object value, DateTime absoluteExpiry)
        {
            var serializedValue = JsonConvert.SerializeObject(value);
            distributedCache.SetString(key.ToString(), serializedValue, new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = absoluteExpiry
            });
        }

        public static T GetJson<T>(this IDistributedCache distributedCache, string key)
        {
            var unserializedValue = distributedCache.GetString(key.ToString());
            if (unserializedValue == null)
                return default(T);
            return JsonConvert.DeserializeObject<T>(unserializedValue);
        }
    }
}   