using Microsoft.Extensions.Caching.Memory;

namespace RiotSharpNET8.Caching
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
		public void Add<TK, TV>(TK key, TV value, TimeSpan slidingExpiry) where TV : class
        {
	        if (key == null) throw new ArgumentNullException(nameof(key));
	        //Add(key, value, slidingExpiry, true);
            //_memoryCache.CreateEntry(key).SetValue(value).SetSlidingExpiration(slidingExpiry);
            _memoryCache.Set(key, value, slidingExpiry);
        }

        /// <inheritdoc />
        /// <remarks>Entries are cached in memory until the specified datetime is reached.</remarks>
        public void Add<TK, TV>(TK key, TV value, DateTime absoluteExpiry) where TV : class
        {
			/*
            if (absoluteExpiry > DateTime.Now)
            {
                var diff = absoluteExpiry - DateTime.Now;
                Add(key, value, diff, false);
            }
            */
			if (key == null) throw new ArgumentNullException(nameof(key));
			//_memoryCache.CreateEntry(key).SetValue(value).SetAbsoluteExpiration(absoluteExpiry);
			_memoryCache.Set(key, value, absoluteExpiry);
        }

        /// <inheritdoc />
        public TV? Get<TK, TV>(TK key) where TV : class
        {
			if (key == null) throw new ArgumentNullException(nameof(key));
            if(_memoryCache.TryGetValue(key, out var value))
			{
				return (TV?)value;
			}
            else
            {
	            return null;
			}
			/*
	        if (!_cache.TryGetValue(key, out var cacheItem)) return null;

	        if (cacheItem.RelativeExpiry.HasValue)
            {
	            if (Monitor.TryEnter(_sync, MonitorWaitToUpdateSliding))
	            {
		            try
		            {
			            _slidingTimes[key].Viewed();
		            }
		            finally
		            {
			            Monitor.Exit(_sync);
		            }
	            }
            }

            return (TV)cacheItem.Value;
            */
		}

        /// <inheritdoc />
        /// <remarks>The result of the operation is not returned to the caller.</remarks>
        public void Remove<TK>(TK key)
        {
			if (key == null) throw new ArgumentNullException(nameof(key));
			_memoryCache.Remove(key);
			/*
            if(key is null) return;

            if (Monitor.TryEnter(_sync, DefaultMonitorWait))
			{
				try
				{
					_cache.Remove(key);
					_slidingTimes.Remove(key);
				}
				finally
				{
					Monitor.Exit(_sync);
				}
			}
            */
		}

        /// <inheritdoc />
        public void Clear()
        {
			_memoryCache.Clear();
			/*
            if (Monitor.TryEnter(_sync, DefaultMonitorWait))
            {
                try
                {
                    _cache.Clear();
                    _slidingTimes.Clear();
                }
                finally
                {
                    Monitor.Exit(_sync);
                }
            }
            */
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


		/// <inheritdoc />
		public int Count()
		{
			return _memoryCache.Count;
			/*
            if (Monitor.TryEnter(_sync, DefaultMonitorWait))
            {
                try
                {
                    return _cache.Keys.Count;
                }
                finally
                {
                    Monitor.Exit(_sync);
                }
            }

            return -1;
            */
		}

        /*
        private void Add<TK, TV>(TK key, TV value, TimeSpan timeSpan, bool isSliding) where TV : class
        {
            if (Monitor.TryEnter(_sync, DefaultMonitorWait))
            {
                try
                {
                    Remove(key);
                    _cache.Add(key, new CacheItem(value, isSliding ? timeSpan : (TimeSpan?)null));

                    if (isSliding)
                    {
                        _slidingTimes.Add(key, new SlidingDetails(timeSpan));
                    }

                    StartObserving(key, timeSpan);
                }
                finally
                {
                    Monitor.Exit(_sync);
                }
            }
        }

        private void StartObserving<TK>(TK key, TimeSpan timeSpan)
        {
            Timer timer = null;
            timer = new Timer(x =>
            {
                TryPurgeItem(key);
                timer?.Dispose();
            }, key, timeSpan, TimeSpan.FromMilliseconds(-1));
        }

        private void TryPurgeItem<TK>(TK key)
        {
            if (_slidingTimes.ContainsKey(key))
            {
                if (!_slidingTimes[key].CanExpire(out var tryAfter))
                {
                    StartObserving(key, tryAfter);
                    return;
                }
            }

            Remove(key);
        }

        private class CacheItem
        {
            public CacheItem(object value, TimeSpan? relativeExpiry)
            {
                Value = value;
                RelativeExpiry = relativeExpiry;
            }

            public object Value { get; }
            public TimeSpan? RelativeExpiry { get; }
        }

        private class SlidingDetails
        {
            private readonly TimeSpan _relativeExpiry;
            private DateTime _expireAt;

            public SlidingDetails(TimeSpan relativeExpiry)
            {
                _relativeExpiry = relativeExpiry;
                Viewed();
            }

            public bool CanExpire(out TimeSpan tryAfter)
            {
                tryAfter = _expireAt - DateTime.Now;
                return (0 > tryAfter.Ticks);
            }

            public void Viewed()
            {
                _expireAt = DateTime.Now.Add(_relativeExpiry);
            }
        }
        */
    }
}
