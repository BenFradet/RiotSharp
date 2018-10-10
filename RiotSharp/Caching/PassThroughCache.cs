using System;

namespace RiotSharp.Caching
{
    /// <summary>
    /// Implementation of ICache for disabling cache
    /// </summary>
    public class PassThroughCache : ICache
    {
        /// <inheritdoc />
        public void Add<TK, TV>(TK key, TV value, TimeSpan slidingExpiry) where TV : class
        {
        }

        /// <inheritdoc />
        public void Add<TK, TV>(TK key, TV value, DateTime absoluteExpiry) where TV : class
        {
        }

        /// <inheritdoc />
        public void Clear()
        {
        }

        /// <inheritdoc />
        public TV Get<TK, TV>(TK key) where TV : class
        {
            return null;
        }

        /// <inheritdoc />
        public void Remove<TK>(TK key)
        {
        }
    }
}
