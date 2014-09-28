// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cache.cs" company="">
//
// </copyright>
// <summary>
//   The cache.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Caching;

namespace RiotSharp
{
    /// <summary>
    /// The cache.
    /// </summary>
    static class Cache
    {
        /// <summary>
        /// The cache.
        /// </summary>
        private static readonly ObjectCache cache = MemoryCache.Default;

        /// <summary>
        /// The lock obj.
        /// </summary>
        private static readonly object LockObj = new object();

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public static T Get<T>(string key) where T : class
        {
            lock (LockObj)
            {
                if (cache.Contains(key))
                {
                    return (T)cache[key];
                }

                return null;
            }
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="toAdd">
        /// The to add.
        /// </param>
        /// <typeparam name="T">
        /// The Class.
        /// </typeparam>
        public static void Add<T>(string key, T toAdd) where T : class
        {
            lock (LockObj)
            {
                if (toAdd != null)
                {
                    cache[key] = toAdd;
                }
            }
        }
    }
}
