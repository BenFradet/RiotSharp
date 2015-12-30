using System;
using System.Collections.Generic;
namespace RiotSharp
{
    /// <summary>
    /// Interface for caching data in-memory.
    /// </summary>
    interface ICache
    {
        /// <summary>
        /// Add a (key, value) pair to the cache with a relative expiry time (e.g. 2 mins).
        /// </summary>
        /// <typeparam name="K">Type of the key.</typeparam>
        /// <typeparam name="V">Type of the value which has to be a reference type.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="slidingExpiry">The sliding time at the end of which the (key, value) pair should expire and
        /// be purged from the cache.</param>
        void Add<K, V>(K key, V value, TimeSpan slidingExpiry) where V : class;

        /// <summary>
        /// Add a (key, value) pair to the cache with an absolute expiry date (e.g. 23:33:00 03/04/2030)
        /// </summary>
        /// <typeparam name="K">Type of the key.</typeparam>
        /// <typeparam name="V">Type of the value which has to be a reference type.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="absoluteExpiry">The absolute expiry date when the (key, value) pair should expire and
        /// be purged from the cache.</param>
        void Add<K, V>(K key, V value, DateTime absoluteExpiry) where V : class;

        /// <summary>
        /// Get a value from the cache.
        /// </summary>
        /// <typeparam name="K">Type of the key.</typeparam>
        /// <typeparam name="V">Type of the value which has to be a reference type.</typeparam>
        /// <param name="key">The key</param>
        /// <returns>The value if the key exists in the cache, null otherwise.</returns>
        V Get<K, V>(K key) where V : class;

        /// <summary>
        /// Remove the value associated with the specified key from the cache.
        /// </summary>
        /// <typeparam name="K">Type of the key.</typeparam>
        /// <param name="key">The key.</param>
        void Remove<K>(K key);

        /// <summary>
        /// Clear the cache.
        /// </summary>
        void Clear();

        /// <summary>
        /// Enumerator for the keys of a specific type.
        /// </summary>
        /// <typeparam name="K">Type of the key.</typeparam>
        /// <returns>Enumerator for the keys of a specific type.</returns>
        IEnumerable<K> Keys<K>();

        /// <summary>
        /// Enumerator for all keys.
        /// </summary>
        /// <returns>Enumerator for all keys.</returns>
        IEnumerable<object> Keys();

        /// <summary>
        /// Enumerator for the values of a specific type.
        /// </summary>
        /// <typeparam name="V">Type of the value which has to be a reference type.</typeparam>
        /// <returns>Enumerator for the values of a specific type.</returns>
        IEnumerable<V> Values<V>() where V : class;

        /// <summary>
        /// Enumerator for all values.
        /// </summary>
        /// <returns>Enumerator for all values.</returns>
        IEnumerable<object> Values();

        /// <summary>
        /// Total amount of (key, value) pairs in the cache.
        /// </summary>
        /// <returns>Total amount of (key, value) pairs in the cache.</returns>
        int Count();
    }
}
