namespace RiotSharp.Core.Caching
{
    /// <summary>
    /// "Implementation" of ICache for disabling cache
    /// </summary>
    public class PassThroughCache : ICache
    {
        /// <inheritdoc />
        public void Add<TK, TV>(TK key, TV value, TimeSpan slidingExpiry)
        {
        }

        /// <inheritdoc />
        public void Add<TK, TV>(TK key, TV value, DateTime absoluteExpiry)
        {
        }

        /// <inheritdoc />
        public void Clear()
        {
        }

        public int Count()
        {
	        throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool TryGet<TK, TV>(TK key, out TV? value)
        {
            value = default;
            return false;
        }

        /// <inheritdoc />
        public void Remove<TK>(TK key)
        {
        }
    }
}
