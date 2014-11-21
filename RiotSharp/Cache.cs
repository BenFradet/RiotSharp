using System.Runtime.Caching;

namespace RiotSharp
{
    static class Cache
    {
        private static readonly ObjectCache cache = MemoryCache.Default;
        private static readonly object lockObj = new object();

        public static T Get<T>(string key) where T : class
        {
            lock (lockObj)
            {
                if (cache.Contains(key))
                {
                    return (T)cache[key];
                }
                return null;
            }
        }

        public static void Add<T>(string key, T toAdd) where T : class
        {
            lock (lockObj)
            {
                if (toAdd != null)
                {
                    cache[key] = toAdd;
                }
            }
        }
    }
}
