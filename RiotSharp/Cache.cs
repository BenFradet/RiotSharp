using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;

namespace RiotSharp
{
    public class Cache : ICache
    {
        private IDictionary<object, CacheItem> cache = new Dictionary<object, CacheItem>();
        private IDictionary<object, SlidingDetails> slidingTimes = new Dictionary<object, SlidingDetails>();

        private const int DefaultMonitorWait = 1000;
        private const int MonitorWaitToUpdateSliding = 500;

        private readonly object sync = new object();

        #region ICache interface

        /// <summary>
        /// Add a (key, value) pair to the cache with a relative expiry time (e.g. 2 mins).
        /// </summary>
        /// <typeparam name="K">Type of the key.</typeparam>
        /// <typeparam name="V">Type of the value which has to be a reference type.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="slidingExpiry">The sliding time at the end of which the (key, value) pair should expire and
        /// be purged from the cache.</param>
        public void Add<K, V>(K key, V value, TimeSpan slidingExpiry) where V : class
        {
            Add(key, value, slidingExpiry, true);
        }

        /// <summary>
        /// Add a (key, value) pair to the cache with an absolute expiry date (e.g. 23:33:00 03/04/2030)
        /// </summary>
        /// <typeparam name="K">Type of the key.</typeparam>
        /// <typeparam name="V">Type of the value which has to be a reference type.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="absoluteExpiry">The absolute expiry date when the (key, value) pair should expire and
        /// be purged from the cache.</param>
        public void Add<K, V>(K key, V value, DateTime absoluteExpiry) where V : class
        {
            if (absoluteExpiry > DateTime.Now)
            {
                var diff = absoluteExpiry - DateTime.Now;
                Add(key, value, diff, false);
            }
        }

        /// <summary>
        /// Get a value from the cache.
        /// </summary>
        /// <typeparam name="K">Type of the key.</typeparam>
        /// <typeparam name="V">Type of the value which has to be a reference type.</typeparam>
        /// <param name="key">The key</param>
        /// <returns>The value if the key exists in the cache, null otherwise.</returns>
        public V Get<K, V>(K key) where V : class
        {
            if (cache.ContainsKey(key))
            {
                var cacheItem = cache[key];

                if (cacheItem.RelativeExpiry.HasValue)
                {
                    if (Monitor.TryEnter(sync, MonitorWaitToUpdateSliding))
                    {
                        try
                        {
                            slidingTimes[key].Viewed();
                        }
                        finally
                        {
                            Monitor.Exit(sync);
                        }
                    }
                }

                return (V)cacheItem.Value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Remove the value associated with the specified key from the cache.
        /// </summary>
        /// <typeparam name="K">Type of the key.</typeparam>
        /// <param name="key">The key.</param>
        public void Remove<K>(K key)
        {
            if (!Equals(key, null))
            {
                cache.Remove(key);
                slidingTimes.Remove(key);
            }
        }

        /// <summary>
        /// Clear the cache.
        /// </summary>
        public void Clear()
        {
            if (Monitor.TryEnter(sync, DefaultMonitorWait))
            {
                try
                {
                    cache.Clear();
                    slidingTimes.Clear();
                }
                finally
                {
                    Monitor.Exit(sync);
                }
            }
        }

        /// <summary>
        /// Enumerator for the keys of a specific type.
        /// </summary>
        /// <typeparam name="K">Type of the key.</typeparam>
        /// <returns>Enumerator for the keys of a specific type.</returns>
        public IEnumerable<K> Keys<K>()
        {
            if (Monitor.TryEnter(sync, DefaultMonitorWait))
            {
                try
                {
                    return cache.Keys.Where(k => k.GetType() == typeof(K)).Cast<K>().ToList();
                }
                finally
                {
                    Monitor.Exit(sync);
                }
            }
            else
            {
                return Enumerable.Empty<K>();
            }
        }

        /// <summary>
        /// Enumerator for all keys.
        /// </summary>
        /// <returns>Enumerator for all keys.</returns>
        public IEnumerable<object> Keys()
        {
            if (Monitor.TryEnter(sync, DefaultMonitorWait))
            {
                try
                {
                    return cache.Keys.ToList();
                }
                finally
                {
                    Monitor.Exit(sync);
                }
            }
            else
            {
                return Enumerable.Empty<object>();
            }
        }

        /// <summary>
        /// Enumerator for the values of a specific type.
        /// </summary>
        /// <typeparam name="V">Type of the value which has to be a reference type.</typeparam>
        /// <returns>Enumerator for the values of a specific type.</returns>
        public IEnumerable<V> Values<V>() where V : class
        {
            if (Monitor.TryEnter(sync, DefaultMonitorWait))
            {
                try
                {
                    return cache.Values
                        .Select(cacheItem => cacheItem.Value)
                        .Where(v => v.GetType() == typeof(V))
                        .Cast<V>().ToList();
                }
                finally
                {
                    Monitor.Exit(sync);
                }
            }
            else
            {
                return Enumerable.Empty<V>();
            }
        }

        /// <summary>
        /// Enumerator for all values.
        /// </summary>
        /// <returns>Enumerator for all values.</returns>
        public IEnumerable<object> Values()
        {
            if (Monitor.TryEnter(sync, DefaultMonitorWait))
            {
                try
                {
                    return cache.Values.Select(cacheItem => cacheItem.Value).ToList();
                }
                finally
                {
                    Monitor.Exit(sync);
                }
            }
            else
            {
                return Enumerable.Empty<object>();
            }
        }

        /// <summary>
        /// Total amount of (key, value) pairs in the cache.
        /// </summary>
        /// <returns>Total amount of (key, value) pairs in the cache.</returns>
        public int Count()
        {
            if (Monitor.TryEnter(sync, DefaultMonitorWait))
            {
                try
                {
                    return cache.Keys.Count;
                }
                finally
                {
                    Monitor.Exit(sync);
                }
            }
            else
            {
                return -1;
            }
        }

        #endregion

        private void Add<K, V>(K key, V value, TimeSpan timeSpan, bool isSliding) where V : class
        {
            if (Monitor.TryEnter(sync, DefaultMonitorWait))
            {
                try
                {
                    Remove(key);
                    cache.Add(key, new CacheItem(value, isSliding ? timeSpan : (TimeSpan?)null));

                    if (isSliding)
                    {
                        slidingTimes.Add(key, new SlidingDetails(timeSpan));
                    }

                    StartObserving(key, timeSpan);
                }
                finally
                {
                    Monitor.Exit(sync);
                }
            }
        }

        private void StartObserving<K>(K key, TimeSpan timeSpan)
        {
            Observable.Timer(timeSpan)
                .Subscribe(x => TryPurgeItem(key));
        }

        private void TryPurgeItem<K>(K key)
        {
            if (slidingTimes.ContainsKey(key))
            {
                TimeSpan tryAfter;
                if (!slidingTimes[key].CanExpire(out tryAfter))
                {
                    StartObserving(key, tryAfter);
                    return;
                }
            }

            Remove(key);
        }

        private class CacheItem
        {
            public CacheItem() { }

            public CacheItem(object value, TimeSpan? relativeExpiry)
            {
                Value = value;
                RelativeExpiry = relativeExpiry;
            }

            public object Value { get; set; }
            public TimeSpan? RelativeExpiry { get; set; }
        }

        private class SlidingDetails
        {
            private TimeSpan relativeExpiry;
            private DateTime expireAt;

            public SlidingDetails(TimeSpan relativeExpiry)
            {
                this.relativeExpiry = relativeExpiry;
                Viewed();
            }

            public bool CanExpire(out TimeSpan tryAfter)
            {
                tryAfter = expireAt - DateTime.Now;
                return (0 > tryAfter.Ticks);
            }

            public void Viewed()
            {
                expireAt = DateTime.Now.Add(relativeExpiry);
            }
        }
    }
}
