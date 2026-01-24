namespace RiotSharp.Core.Caching
{
    /// <summary>
    /// Interface for caching data in-memory.
    /// </summary>
    public interface ICache
    {
        /// <summary>
        /// Add a (key, value) pair to the cache with a relative expiry time (e.g. 2 mins).
        /// </summary>
        /// <typeparam name="TK">Type of the key.</typeparam>
        /// <typeparam name="TV">Type of the value.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="slidingExpiry">The sliding time at the end of which the (key, value) pair should expire and be purged from the cache.</param>
        void Add<TK, TV>(TK key, TV value, TimeSpan slidingExpiry);

        /// <summary>
        /// Add a (key, value) pair to the cache with an absolute expiry date (e.g. 23:33:00 03/04/2030)
        /// </summary>
        /// <typeparam name="TK">Type of the key.</typeparam>
        /// <typeparam name="TV">Type of the value.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="absoluteExpiry">The absolute expiry date when the (key, value) pair should expire and be purged from the cache.</param>
        void Add<TK, TV>(TK key, TV value, DateTime absoluteExpiry);

        /// <summary>
        /// Get a value from the cache.
        /// </summary>
        /// <typeparam name="TK">Type of the key.</typeparam>
        /// <typeparam name="TV">Type of the value.</typeparam>
        /// <param name="key">The key</param>
        /// <param name="value">The value associated with the specified key, or null/default if not found.</param>
        /// <returns>If the value could be retrieved or not.</returns>
        bool TryGet<TK, TV>(TK key, out TV? value);

        /// <summary>
        /// Remove the value associated with the specified key from the cache.
        /// </summary>
        /// <typeparam name="TK">Type of the key.</typeparam>
        /// <param name="key">The key.</param>
        void Remove<TK>(TK key);

        /// <summary>
        /// Clear the cache.
        /// </summary>
        void Clear();

        /// <summary>
        /// Get the number of items in the cache. Most likely only used for statistics or testing.
        /// </summary>
        int Count();
    }
}
