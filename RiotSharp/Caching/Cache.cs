using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RiotSharp.Caching
{
    /// <summary>
    /// In-memory cache implementation based on <see cref="ICache"/>
    /// </summary>
    public class Cache : ICache
    {
        private readonly IDictionary<object, CacheItem> _cache = new Dictionary<object, CacheItem>();
        private readonly IDictionary<object, SlidingDetails> _slidingTimes = new Dictionary<object, SlidingDetails>();

        private const int DefaultMonitorWait = 1000;
        private const int MonitorWaitToUpdateSliding = 500;

        private readonly object _sync = new object();

        #region ICache interface
        /// <inheritdoc />
        public void Add<TK, TV>(TK key, TV value, TimeSpan slidingExpiry) where TV : class
        {
            Add(key, value, slidingExpiry, true);
        }

        /// <inheritdoc />
        public void Add<TK, TV>(TK key, TV value, DateTime absoluteExpiry) where TV : class
        {
            if (absoluteExpiry > DateTime.Now)
            {
                var diff = absoluteExpiry - DateTime.Now;
                Add(key, value, diff, false);
            }
        }

        /// <inheritdoc />
        public TV Get<TK, TV>(TK key) where TV : class
        {
            if (_cache.ContainsKey(key))
            {
                var cacheItem = _cache[key];

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
            }

            return null;
        }

        /// <inheritdoc />
        public void Remove<TK>(TK key)
        {
            if (!Equals(key, null))
            {
                _cache.Remove(key);
                _slidingTimes.Remove(key);
            }
        }

        /// <inheritdoc />
        public void Clear()
        {
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
        }
        #endregion

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

        /// <summary>
        /// Total amount of (key, value) pairs in the cache.
        /// </summary>
        /// <returns>Total amount of (key, value) pairs in the cache.</returns>
        internal int Count()
        {
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
        }

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
    }
}
