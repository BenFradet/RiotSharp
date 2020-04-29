using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using RiotSharp.Caching;

namespace RiotSharp.AspNetCore.Caching
{
    /// <summary>
    /// Implementation of ICache with AspNetCore's distributed cache
    /// </summary>
    public class DistributedCache : ICache
    {
        private readonly IDistributedCache _distributed;
        private readonly List<object> _usedKeys;

        /// <summary>
        /// Initializes a new instance of the <see cref="DistributedCache"/> class.
        /// </summary>
        /// <param name="memoryCache">The memory cache.</param>
        public DistributedCache(IDistributedCache memoryCache)
        {
            _distributed = memoryCache;
            _usedKeys = new List<object>();
        }

        /// <inheritdoc />
        public void Add<TK, TV>(TK key, TV value, TimeSpan slidingExpiry) where TV : class
        {
            _usedKeys.Add(key);
            _distributed.SetJson(key.ToString(), value, slidingExpiry);
        }

        /// <inheritdoc />
        public void Add<TK, TV>(TK key, TV value, DateTime absoluteExpiry) where TV : class
        {
            _usedKeys.Add(key);
            _distributed.SetJson(key.ToString(), value, absoluteExpiry);
        }

        /// <inheritdoc />
        public void Clear()
        {
            foreach (var usedKey in _usedKeys)
            {
                _distributed.Remove(usedKey.ToString());
                _usedKeys.Remove(usedKey);
            }
        }

        /// <inheritdoc />
        public TV Get<TK, TV>(TK key) where TV : class
        {
            return _distributed.GetJson<TV>(key.ToString());
        }

        /// <inheritdoc />
        public void Remove<TK>(TK key)
        {
            _distributed.Remove(key.ToString());
        }
    }
}
