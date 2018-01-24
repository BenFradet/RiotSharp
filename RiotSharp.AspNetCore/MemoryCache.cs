using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using RiotSharp.Caching;

namespace RiotSharp.AspNetCore
{
    /// <summary>
    /// Implementation of ICache with AspNetCore's local in-memory cache
    /// </summary>
    public class MemoryCache : ICache
    {
        private IMemoryCache memoryCache;
        private List<object> usedKeys;

#pragma warning disable CS1591
        public MemoryCache(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
            usedKeys = new List<object>();
        }

        public void Add<K, V>(K key, V value, TimeSpan slidingExpiry) where V : class
        {
            usedKeys.Add(key);
            memoryCache.Set(key, value, slidingExpiry);
        }

        public void Add<K, V>(K key, V value, DateTime absoluteExpiry) where V : class
        {
            usedKeys.Add(key);
            memoryCache.Set(key, value, absoluteExpiry);
        }

        public void Clear()
        {
            foreach (var usedKey in usedKeys)
            {    
                memoryCache.Remove(usedKey);
                usedKeys.Remove(usedKey);
            }
        }

        public V Get<K, V>(K key) where V : class
        {
            V output = null;
            memoryCache.TryGetValue(key, out output);
            return output;
        }

        public void Remove<K>(K key)
        {
            memoryCache.Remove(key);
        }
#pragma warning restore
    }
}
