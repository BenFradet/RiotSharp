using System;
using System.IO;
using Newtonsoft.Json;

namespace RiotSharp
{
    public class FileCache : ICache
    {

        /// <summary>
        /// Create file cache instance
        /// </summary>
        /// <param name="dir">Directory for the cache to store in</param>
        public FileCache(string dir = "/cache")
        {
            _directory = Path.Combine(Directory.GetCurrentDirectory(), dir);
        }

        private static string _directory;

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

        public bool IsExpired<T>(CacheData<T> data)
        {
            return data == null || DateTime.Now > data.CreatedAt.AddMinutes(data.TtlMinutes);
        }

        public override void Add<TK, TV>(TK key, TV value, TimeSpan slidingExpiry) where TV : class
        {
            Store(key, value, (long) slidingExpiry.TotalMinutes);
        }

        public override void Add<TK, TV>(TK key, TV value, DateTime absoluteExpiry) where TV : class
        {
            Store(key, value, (long) (absoluteExpiry - DateTime.Now).TotalMinutes);
        }

        public override void Clear()
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

        public override TV Get<TK, TV>(TK key) where TV : class
        {
            var data = Load<CacheData<TV>>(key.ToString());

            return IsExpired(data) ? null : data.Data;
        }

        public override void Remove<TK>(TK key)
        {
            var path = GetPath(key.ToString());
            File.Delete(path);
        }
    }
}
