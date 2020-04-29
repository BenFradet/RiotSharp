using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using RiotSharp.Caching;

namespace RiotSharp.AspNetCore.Caching
{
    /// <summary>
    /// Hybrid cache implementation with usage of in-memory and distributed cache
    /// </summary>
    public class HybridCache : ICache
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IMemoryCache _memoryCache;
        private readonly List<object> _usedKeys;
        private readonly TimeSpan _slidingExpiry;

        /// <summary>
        /// Initializes a new instance of the <see cref="HybridCache"/> class.
        /// </summary>
        /// <param name="memoryCache">The memory cache.</param>
        /// <param name="distributedCache">The distributed cache.</param>
        /// <param name="slidingExpiry">Used to set expiry in memory cache after data is loaded for first time from distributed cache.</param>
        public HybridCache(IMemoryCache memoryCache, IDistributedCache distributedCache, TimeSpan slidingExpiry)
        {
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
            _slidingExpiry = slidingExpiry;
            _usedKeys = new List<object>();
        }

        /// <inheritdoc />
        public void Add<TK, TV>(TK key, TV value, TimeSpan slidingExpiry) where TV : class
        {
            _usedKeys.Add(key);
            _memoryCache.Set(key, value, slidingExpiry);
            _distributedCache.SetJson(key.ToString(), value, slidingExpiry);
        }

        /// <inheritdoc />
        public void Add<TK, TV>(TK key, TV value, DateTime absoluteExpiry) where TV : class
        {
            _usedKeys.Add(key);
            _memoryCache.Set(key, value, absoluteExpiry);
            _distributedCache.SetJson(key.ToString(), value, absoluteExpiry);
        }

        /// <inheritdoc />
        public void Clear()
        {
            foreach (var usedKey in _usedKeys)
            {
                _memoryCache.Remove(usedKey);
                _distributedCache.Remove(usedKey.ToString());
                _usedKeys.Remove(usedKey);
            }
        }

        /// <inheritdoc />
        public TV Get<TK, TV>(TK key) where TV : class
        {
            if (_memoryCache.TryGetValue(key, out TV output))
                return output;

            output = _distributedCache.GetJson<TV>(key.ToString());
            if (output != null)
            {
                _usedKeys.Add(key);
                _memoryCache.Set(key, output, _slidingExpiry);
            }               
            return output;
        }

        /// <inheritdoc />
        public void Remove<TK>(TK key)
        {
            _memoryCache.Remove(key);
            _distributedCache.Remove(key.ToString());
        }
    }
}
