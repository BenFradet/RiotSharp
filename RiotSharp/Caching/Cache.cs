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
        private readonly IDictionary<object, CacheData<object>> _cache = new Dictionary<object, CacheData<object>>();

        private const int DefaultMonitorWait = 1000;

        private readonly object _sync = new object();

        #region ICache interface
        /// <inheritdoc />
        public void Add<TK, TV>(TK key, TV value, TimeSpan slidingExpiry) where TV : class
        {
            Store(key, value, slidingExpiry);
        }

        /// <inheritdoc />
        public void Add<TK, TV>(TK key, TV value, DateTime absoluteExpiry) where TV : class
        {
            if (absoluteExpiry > DateTime.Now)
            {
                var diff = absoluteExpiry - DateTime.Now;
                Store(key, value, diff);
            }
        }

        /// <inheritdoc />
        public TV Get<TK, TV>(TK key) where TV : class
        {
            return Load<TK, TV>(key);
        }
                
        /// <inheritdoc />
        public void Remove<TK>(TK key)
        {
            if (!Equals(key, null))
            {
                _cache.Remove(key);
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
                        .Select(cacheItem => cacheItem.Data)
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
                    return _cache.Values.Select(cacheItem => cacheItem.Data).ToList();
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

        private TV Load<TK, TV>(TK key) where TV : class
        {
            CacheData<TV> data = null;
            if (Monitor.TryEnter(_sync, DefaultMonitorWait))
            {
                try
                {
                    CacheData<object> objData;
                    this._cache.TryGetValue(key, out objData);
                    if (objData.Data is TV)
                    {
                        data = objData as CacheData<TV>;
                    }
                }
                finally
                {
                    Monitor.Exit(_sync);
                }
            }

            return IsExpired(data) ? null : data.Data;
        }

        private void Store<TK, TV>(TK key, TV value, TimeSpan timeSpan) where TV : class
        {
            if (Monitor.TryEnter(_sync, DefaultMonitorWait))
            {
                try
                {
                    Remove(key);
                    _cache.Add(key, new CacheData<object>((long)timeSpan.TotalMinutes, value));
                }
                finally
                {
                    Monitor.Exit(_sync);
                }
            }
        }

        private bool IsExpired<T>(CacheData<T> data)
        {
            return data == null || DateTime.Now > data.CreatedAt.AddMinutes(data.TtlMinutes);
        }
    }
}
