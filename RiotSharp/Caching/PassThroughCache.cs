using System;

namespace RiotSharp.Caching
{
    /// <summary>
    /// Implementation of ICache for disabling cache
    /// </summary>
    public class PassThroughCache : ICache
    {
        public void Add<K, V>(K key, V value, TimeSpan slidingExpiry) where V : class
        {
            return;
        }

        public void Add<K, V>(K key, V value, DateTime absoluteExpiry) where V : class
        {
            return;
        }

        public void Clear()
        {
            return;
        }

        public V Get<K, V>(K key) where V : class
        {
            return null;
        }

        public void Remove<K>(K key)
        {
            return;
        }
    }
}
