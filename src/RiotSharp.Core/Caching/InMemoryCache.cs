using Microsoft.Extensions.Caching.Memory;

namespace RiotSharp.Core.Caching
{
    /// <summary>
    /// In-memory cache implementation based on <see cref="ICache"/>
    /// </summary>
    public class InMemoryCache : ICache
    {
        //private readonly IDictionary<object, CacheItem> _cache = new Dictionary<object, CacheItem>();
        //private readonly IDictionary<object, SlidingDetails> _slidingTimes = new Dictionary<object, SlidingDetails>();
        //private readonly object _sync = new object();
        //private const int DefaultMonitorWait = 1000;
        //private const int MonitorWaitToUpdateSliding = 500;

        /// <summary>
        /// The in memory cache. It should be thread safe. Not using the interface because it doesn't have the clear method.
        /// </summary>
        private readonly MemoryCache _memoryCache;

		/// <summary>
		/// Constructor for the in-memory cache.
		/// </summary>
		/// <param name="expirationScanFrequency">The timespan of which the elements in the cache will be checked. Default is 5 minutes.</param>
		public InMemoryCache(TimeSpan? expirationScanFrequency = null)
		{
			TimeSpan scanFrequency = expirationScanFrequency ?? TimeSpan.FromMinutes(5);
			
            _memoryCache = new MemoryCache(new MemoryCacheOptions
			{
				ExpirationScanFrequency = scanFrequency
			});
		}

		#region ICache interface
		/// <inheritdoc />
		/// <remarks>Entries are cached in memory for the specified duration.</remarks>
		public void Add<TK, TV>(TK key, TV value, TimeSpan slidingExpiry)
        {
	        if (key == null) throw new ArgumentNullException(nameof(key));
            _memoryCache.Set(key, value, slidingExpiry);
        }

        /// <inheritdoc />
        /// <remarks>Entries are cached in memory until the specified datetime is reached.</remarks>
        public void Add<TK, TV>(TK key, TV value, DateTime absoluteExpiry)
        {
			if (key == null) throw new ArgumentNullException(nameof(key));
			_memoryCache.Set(key, value, absoluteExpiry);
        }

        /// <inheritdoc />
        public bool TryGet<TK, TV>(TK key, out TV? value)
        {
			if (key == null) throw new ArgumentNullException(nameof(key));
            return _memoryCache.TryGetValue(key, out value);
		}

        /// <inheritdoc />
        /// <remarks>The result of the operation is not returned to the caller.</remarks>
        public void Remove<TK>(TK key)
        {
			if (key == null) throw new ArgumentNullException(nameof(key));
			_memoryCache.Remove(key);
		}

        /// <inheritdoc />
        public void Clear()
        {
			_memoryCache.Clear();
		}

        /// <inheritdoc />
        public int Count()
        {
            return _memoryCache.Count;
        }
        #endregion

        //Enumerators are not used in the current implementation. Perhaps they will be used in the future.
        /*
		#region Enumerator methods

		/// <summary>
		/// Enumerator for the keys of a specific type.
		/// </summary>
		/// <typeparam name="TK">Type of the key.</typeparam>
		/// <returns>Enumerator for the keys of a specific type.</returns>
		internal IEnumerable<TK> Keys<TK>()
        {
            if (Monitor.TryEnter(_sync, DefaultMonitorWait))
            {
                try
                {
                    return _cache.Keys.Where(k => k.GetType() == typeof(TK)).Cast<TK>().ToList();
                }
                finally
                {
                    Monitor.Exit(_sync);
                }
            }

            return Enumerable.Empty<TK>();
        }

        /// <summary>
        /// Enumerator for all keys.
        /// </summary>
        /// <returns>Enumerator for all keys.</returns>
        internal IEnumerable<object> Keys()
        {
            if (Monitor.TryEnter(_sync, DefaultMonitorWait))
            {
                try
                {
                    return _cache.Keys.ToList();
                }
                finally
                {
                    Monitor.Exit(_sync);
                }
            }

            return Enumerable.Empty<object>();
        }

        /// <summary>
        /// Enumerator for the values of a specific type.
        /// </summary>
        /// <typeparam name="TV">Type of the value which has to be a reference type.</typeparam>
        /// <returns>Enumerator for the values of a specific type.</returns>
        internal IEnumerable<TV> Values<TV>() where TV : class
        {
            if (Monitor.TryEnter(_sync, DefaultMonitorWait))
            {
                try
                {
                    return _cache.Values
                        .Select(cacheItem => cacheItem.Value)
                        .Where(v => v.GetType() == typeof(TV))
                        .Cast<TV>().ToList();
                }
                finally
                {
                    Monitor.Exit(_sync);
                }
            }

            return Enumerable.Empty<TV>();
        }

        /// <summary>
        /// Enumerator for all values.
        /// </summary>
        /// <returns>Enumerator for all values.</returns>
        internal IEnumerable<object> Values()
        {
            if (Monitor.TryEnter(_sync, DefaultMonitorWait))
            {
                try
                {
                    return _cache.Values.Select(cacheItem => cacheItem.Value).ToList();
                }
                finally
                {
                    Monitor.Exit(_sync);
                }
            }

            return Enumerable.Empty<object>();
        }

		#endregion
        */
    }
}
