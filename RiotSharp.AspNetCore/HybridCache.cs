using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using RiotSharp.Caching;

namespace RiotSharp.AspNetCore
{
    /// <summary>
    /// Hybrid cache implementation with usage of in-memory and distributed cache
    /// </summary>
    public class HybridCache : ICache
    {
        private IDistributedCache distributedCache;
        private IMemoryCache memoryCache;
        private List<object> usedKeys;
        private TimeSpan slidingExpiry;

#pragma warning disable CS1591

        /// <param name="slidingExpiry">Used to set expiry in memory cache after data is loaded for first time from distributed cache.</param>
        public HybridCache(IMemoryCache memoryCache, IDistributedCache distributedCache, TimeSpan slidingExpiry)
        {
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;
            this.slidingExpiry = slidingExpiry;
            usedKeys = new List<object>();
        }

        public void Add<K, V>(K key, V value, TimeSpan slidingExpiry) where V : class
        {
            usedKeys.Add(key);
            memoryCache.Set(key, value, slidingExpiry);
            distributedCache.SetJson(key.ToString(), value, slidingExpiry);
        }

        public void Add<K, V>(K key, V value, DateTime absoluteExpiry) where V : class
        {
            usedKeys.Add(key);
            memoryCache.Set(key, value, absoluteExpiry);
            distributedCache.SetJson(key.ToString(), value, absoluteExpiry);
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
            V output = null;
            if (memoryCache.TryGetValue(key, out output))
                return output;
            else
            {
                output = distributedCache.GetJson<V>(key.ToString());
                if (output != null)
                {
                    usedKeys.Add(key);
                    memoryCache.Set(key, output, slidingExpiry);
                }               
                return output;
            }  
        }

        public void Remove<K>(K key)
        {
            memoryCache.Remove(key);
            distributedCache.Remove(key.ToString());
        }
#pragma warning restore
    }
}
