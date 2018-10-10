using System;
using System.IO;
using Newtonsoft.Json;

namespace RiotSharp.Caching
{
    /// <summary>
    /// Cache implementation which will write the cache to a file.
    /// </summary>
    /// <seealso cref="RiotSharp.Caching.ICache" />
    public class FileCache : ICache
    {
        private static string _directory;

        /// <summary>
        /// Create file cache instance
        /// </summary>
        /// <param name="dir">Directory for the cache to store in</param>
        public FileCache(string dir = "/cache")
        {
            _directory = Path.Combine(Directory.GetCurrentDirectory(), dir);
        }

        /// <inheritdoc />
        public void Add<TK, TV>(TK key, TV value, TimeSpan slidingExpiry) where TV : class
        {
            Store(key, value, (long)slidingExpiry.TotalMinutes);
        }

        /// <inheritdoc />
        public void Add<TK, TV>(TK key, TV value, DateTime absoluteExpiry) where TV : class
        {
            Store(key, value, (long)(absoluteExpiry - DateTime.Now).TotalMinutes);
        }

        /// <inheritdoc />
        public void Clear()
        {
            DirectoryInfo di = new DirectoryInfo(_directory);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        /// <inheritdoc />
        public TV Get<TK, TV>(TK key) where TV : class
        {
            var data = Load<CacheData<TV>>(key.ToString());

            return IsExpired(data) ? null : data.Data;
        }

        /// <inheritdoc />
        public void Remove<TK>(TK key)
        {
            var path = GetPath(key.ToString());
            File.Delete(path);
        }

        private string GetPath(string key)
        {
            return Path.Combine(_directory, key.GetHashCode().ToString());
        }

        private T Load<T>(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }

        private void Store<TK, TV>(TK key, TV value, long ttlMins = 24 * 60 * 7 * 4) // A month
        {
            CacheData<TV> data = new CacheData<TV>(ttlMins, value);
            File.WriteAllText(GetPath(key.ToString()), JsonConvert.SerializeObject(data));
        }

        private bool IsExpired<T>(CacheData<T> data)
        {
            return data == null || DateTime.Now > data.CreatedAt.AddMinutes(data.TtlMinutes);
        }
    }
}
