using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using RiotSharp.Caching;

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
            distributed.SetJson(key.ToString(), value, slidingExpiry);
        }

        public void Add<K, V>(K key, V value, DateTime absoluteExpiry) where V : class
        {
            usedKeys.Add(key);
            distributed.SetJson(key.ToString(), value, absoluteExpiry);
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
            return distributed.GetJson<V>(key.ToString());
        }

        public void Remove<K>(K key)
        {
            distributed.Remove(key.ToString());
        }
#pragma warning restore
    }
}
