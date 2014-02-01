using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace RiotSharp
{
    class Cache
    {
        private static readonly ObjectCache cache = MemoryCache.Default;

        public static T Get<T>(string key) where T : class
        {
            if (cache.Contains(key))
            {
                return (T)cache[key];
            }
            else
            {
                return null;
            }
        }

        public static void Add<T>(string key, T toAdd) where T : class
        {
            cache[key] = toAdd;
        }
    }
}
