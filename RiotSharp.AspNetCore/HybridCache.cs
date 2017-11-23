using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.AspNetCore
{
    /// <summary>
    /// Hybrid cache implementation with usage of in-memory and distributed cache
    /// </summary>
    public class HybridCache : ICache
    {
        private ICache distributedCache;
        private ICache memoryCache;
        private List<object> usedKeys;

#pragma warning disable CS1591
        public HybridCache(ICache memoryCache, ICache distributedCache)
        {
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;
            usedKeys = new List<object>();
        }

        public void Add<K, V>(K key, V value, TimeSpan slidingExpiry) where V : class
        {
            usedKeys.Add(key);
            memoryCache.Add(key, value, slidingExpiry);
            distributedCache.Add(key, value, slidingExpiry);
        }

        public void Add<K, V>(K key, V value, DateTime absoluteExpiry) where V : class
        {
            usedKeys.Add(key);
            memoryCache.Add(key, value, absoluteExpiry);
            distributedCache.Add(key, value, absoluteExpiry);
        }

        public void Clear()
        {
            foreach (var usedKey in usedKeys)
            {
                memoryCache.Remove(usedKey);
                distributedCache.Remove(usedKey.ToString());
                usedKeys.Remove(usedKey);
            }
        }

        public V Get<K, V>(K key) where V : class
        {
            var value = memoryCache.Get<K, V>(key);
            if (value == null)
                return distributedCache.Get<K, V>(key);
            else
                return value;
        }

        public void Remove<K>(K key)
        {
            memoryCache.Remove(key);
            distributedCache.Remove(key.ToString());
        }
#pragma warning restore
    }
}
