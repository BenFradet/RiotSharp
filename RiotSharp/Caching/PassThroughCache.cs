using System;

namespace RiotSharp.Caching
{
    /// <summary>
    /// Implementation of ICache for disabling cache
    /// </summary>
    public class PassThroughCache : ICache
    {
        /// <inheritdoc />
        public void Add<K, V>(K key, V value, TimeSpan slidingExpiry) where V : class
        {
            return;
        }

        /// <inheritdoc />
        public void Add<K, V>(K key, V value, DateTime absoluteExpiry) where V : class
        {
            return;
        }

        /// <inheritdoc />
        public void Clear()
        {
            return;
        }

        /// <inheritdoc />
        public V Get<K, V>(K key) where V : class
        {
            return null;
        }

        /// <inheritdoc />
        public void Remove<K>(K key)
        {
            return;
        }
    }
}
