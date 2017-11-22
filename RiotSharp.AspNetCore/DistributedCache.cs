using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.AspNetCore
{
    /// <summary>
    /// Implementation of ICache with AspNetCore's distributed cache
    /// </summary>
    public class DistributedCache : ICache
    {
        private IDistributedCache distributed;
        private List<object> usedKeys;

#pragma warning disable CS1591
        public DistributedCache(IDistributedCache memoryCache)
        {
            this.distributed = memoryCache;
            usedKeys = new List<object>();
        }

        public void Add<K, V>(K key, V value, TimeSpan slidingExpiry) where V : class
        {
            usedKeys.Add(key);
            var serializedValue = JsonConvert.SerializeObject(value);
            distributed.SetString(key.ToString(), serializedValue, new DistributedCacheEntryOptions
            {
                SlidingExpiration = slidingExpiry
            });
        }

        public void Add<K, V>(K key, V value, DateTime absoluteExpiry) where V : class
        {
            usedKeys.Add(key);
            var serializedValue = JsonConvert.SerializeObject(value);
            distributed.SetString(key.ToString(), serializedValue, new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = absoluteExpiry
            });
        }

        public void Clear()
        {
            foreach (var usedKey in usedKeys)
            {
                distributed.Remove(usedKey.ToString());
                usedKeys.Remove(usedKey);
            }
        }

        public V Get<K, V>(K key) where V : class
        {
            var unserializedValue = distributed.GetString(key.ToString());           
            return JsonConvert.DeserializeObject<V>(unserializedValue);
        }

        public void Remove<K>(K key)
        {
            distributed.Remove(key.ToString());
        }
#pragma warning restore
    }
}
