using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Internal;

namespace RiotSharp.Core.Caching
{
    /// <summary>
    /// In-memory cache implementation based on <see cref="ICache"/>
    /// </summary>
    public class InMemoryCache : ICache
    {
        /// <summary>
        /// The in memory cache. It should be thread safe. Not using the interface because it doesn't have the clear method.
        /// </summary>
        private readonly MemoryCache _memoryCache;

        /// <summary>
        /// Constructor for the in-memory cache.
        /// </summary>
        /// <param name="expirationScanFrequency">The timespan of which the elements in the cache will be checked. Default is 5 minutes.</param>
        /// <param name="clock">The system clock to use for expiration only used for testing purposes!</param>
        public InMemoryCache(TimeSpan? expirationScanFrequency = null, ISystemClock? clock = null)
		{
			TimeSpan scanFrequency = expirationScanFrequency ?? TimeSpan.FromMinutes(1);

            _memoryCache = new MemoryCache(new MemoryCacheOptions
            {
                ExpirationScanFrequency = scanFrequency,
                Clock = clock
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
			// Convert DateTime to DateTimeOffset for proper comparison with ISystemClock
			var absoluteExpiryOffset = new DateTimeOffset(absoluteExpiry, TimeSpan.Zero);
			_memoryCache.Set(key, value, absoluteExpiryOffset);
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
    }
}
